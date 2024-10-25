using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static BankSystem.Globals;
using static BankSystem.Models.Delegates;

namespace BankSystem.Models
{
    internal class DatabaseResponse
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
    }

    internal class DatabaseResponse<T> : DatabaseResponse
    {
        public T? Result { get; set; }
    }

    internal class Database
    {
        private List<DatabaseInternalAccount> _accounts = [];
        private List<Transaction> _transactions = [];
        private string? _adminPassword;

        public event TransactionEventHandler? OnTransactionCompleted;
        public event TransactionEventHandler? OnRiskyTransactionApproved;
        public event TransactionEventHandler? OnRiskyTransactionDenied;
        public event InterWorldTransactionEventHandler? OnAccountWithdraw;
        public event InterWorldTransactionEventHandler? OnAccountDeposit;
        public event RiskyTransactionEventHandler? OnRiskyTransactionRaised;
        public event AccountEventHandler? OnAccountCreated;

        public DatabaseResponse RegisterAccount(Account account, string password)
        {
            var result = _accounts.Where(x => x.Account.LoginName == account.LoginName);
            if (result.Count() == 0)
            {
                _accounts.Add(
                    new DatabaseInternalAccount
                    {
                        Account = account,
                        Password = password,
                        Balance = 0
                    }
                );
                OnAccountCreated?.Invoke(account);
                return new DatabaseResponse { Success = true };
            }
            else
                return new DatabaseResponse
                {
                    Success = false,
                    Message = "登录用户名已被占用。\n\n如果忘记密码，请联系管理员。"
                };
        }

        public bool UpdateAdminPassword(string newPassword, string? originalPassword = null)
        {
            if (_adminPassword == originalPassword)
            {
                _adminPassword = newPassword;
                return true;
            }
            else
                return false;
        }

        public int GetAccountCount()
        {
            return _accounts.Count();
        }

        private DatabaseResponse<DatabaseInternalAccount> GetInternalAccount(string loginName)
        {
            var result = _accounts.Where(x => x.Account.LoginName == loginName);
            if (result.Count() == 0)
            {
                return new DatabaseResponse<DatabaseInternalAccount>
                {
                    Success = false,
                    Message = "没有找到相应登录名的账号。"
                };
            }
            else if (result.Count() > 1)
            {
                return new DatabaseResponse<DatabaseInternalAccount>
                {
                    Success = false,
                    Message = "找到多个相同登录名的账号。\n这是数据库内部错误，请联系管理员。"
                };
            }
            else
            {
                return new DatabaseResponse<DatabaseInternalAccount>
                {
                    Success = true,
                    Result = result.First()
                };
            }
        }

        public DatabaseResponse<Account> GetAccount(string loginName)
        {
            var response = GetInternalAccount(loginName);
            if (!response.Success)
                return new DatabaseResponse<Account>
                {
                    Success = false,
                    Message = response.Message
                };
            return new DatabaseResponse<Account>
            {
                Success = true,
                Result = response.Result!.Account
            };
        }

        public DatabaseResponse<Account> Login(string loginName, string password)
        {
            var response = GetInternalAccount(loginName);
            if (!response.Success)
                return new DatabaseResponse<Account>
                {
                    Success = false,
                    Message = response.Message
                };
            var resultAccount = response.Result!;
            if (resultAccount.Password == password)
            {
                return new DatabaseResponse<Account>
                {
                    Success = true,
                    Result = resultAccount.Account
                };
            }
            else
            {
                return new DatabaseResponse<Account>
                {
                    Success = false,
                    Message = "登录失败。\n\n密码错误。"
                };
            }
        }

        public DatabaseResponse Deposit(Account account, decimal amount)
        {
            var response = GetInternalAccount(account.LoginName);
            if (!response.Success)
                return new DatabaseResponse { Success = false, Message = response.Message };
            var internalAccount = response.Result!;
            internalAccount.Balance += amount;
            var transaction = new Transaction
            {
                FromAccount = null,
                ToAccount = internalAccount.Account,
                Amount = amount
            };
            _transactions.Add(transaction);
            OnTransactionCompleted?.Invoke(transaction);
            OnAccountDeposit?.Invoke(amount);
            return new DatabaseResponse { Success = true };
        }

        public DatabaseResponse Withdraw(Account account, string password, decimal amount)
        {
            var response = GetInternalAccount(account.LoginName);
            if (!response.Success)
                return new DatabaseResponse { Success = false, Message = response.Message };
            var internalAccount = response.Result!;
            if (internalAccount.Password != password)
                return new DatabaseResponse { Success = false, Message = "密码错误。" };
            if (amount > internalAccount.Balance)
                return new DatabaseResponse
                {
                    Success = false,
                    Message = $"余额不足。当前余额 ${internalAccount.Balance:N2}"
                };

            var completedTransactions = _transactions
                .Where(x => x.FromAccount?.AccountId == account.AccountId)
                .Sum(x => x.Amount);
            if (completedTransactions + amount > DAILY_TRANSACTION_LIMIT)
                return new DatabaseResponse { Success = false, Message = "超出每日交易额度（取出与转账的总额）。" };

            internalAccount.Balance -= amount;
            var transaction = new Transaction
            {
                FromAccount = account,
                ToAccount = null,
                Amount = amount
            };
            _transactions.Add(transaction);
            OnTransactionCompleted?.Invoke(transaction);
            OnAccountWithdraw?.Invoke(amount);
            return new DatabaseResponse { Success = true };
        }

        public DatabaseResponse<Transaction> Transact(
            Account FromAccount,
            Account ToAccount,
            string password,
            decimal amount
        )
        {
            var responseFrom = GetInternalAccount(FromAccount.LoginName);
            if (!responseFrom.Success)
                return new DatabaseResponse<Transaction>
                {
                    Success = false,
                    Message = responseFrom.Message
                };
            var internalFromAccount = responseFrom.Result!;
            if (internalFromAccount.Password != password)
                return new DatabaseResponse<Transaction> { Success = false, Message = "密码错误。" };
            if (amount > internalFromAccount.Balance)
                return new DatabaseResponse<Transaction>
                {
                    Success = false,
                    Message = $"余额不足。当前余额 ${internalFromAccount.Balance:N2}"
                };

            var responseTo = GetInternalAccount(ToAccount.LoginName);
            if (!responseTo.Success)
                return new DatabaseResponse<Transaction>
                {
                    Success = false,
                    Message = responseTo.Message
                };
            var internalToAccount = responseTo.Result!;

            var completedTransactions = _transactions
                .Where(x =>
                    DateTime.Now - x.TransactionTime < TimeSpan.FromDays(1)
                    && x.FromAccount?.AccountId == FromAccount.AccountId
                )
                .Sum(x => x.Amount);
            if (completedTransactions + amount > DAILY_TRANSACTION_LIMIT)
            {
                return new DatabaseResponse<Transaction>
                {
                    Success = false,
                    Message = "每日交易额度（取出与转账的总额）已用完。"
                };
            }

            var destAccDailyIntake = _transactions
                .Where(x =>
                    DateTime.Now - x.TransactionTime < TimeSpan.FromDays(1)
                    && x.ToAccount == ToAccount
                )
                .Sum(x => x.Amount);

            var transaction = new Transaction
            {
                FromAccount = internalFromAccount.Account,
                ToAccount = internalToAccount.Account,
                Amount = amount
            };

            if (destAccDailyIntake + amount > DAILY_INTAKE_WARNING_LIMIT)
            {
                OnRiskyTransactionRaised?.Invoke(transaction, destAccDailyIntake);
                return new DatabaseResponse<Transaction>
                {
                    Success = false,
                    Message = "对方本日入账金额已达预警下限。\n\n本次转账需要管理员审核。",
                    Result = transaction
                };
            }

            internalFromAccount.Balance -= amount;
            internalToAccount.Balance += amount;
            _transactions.Add(transaction);
            OnTransactionCompleted?.Invoke(transaction);
            return new DatabaseResponse<Transaction> { Success = true, Result = transaction };
        }

        public DatabaseResponse<decimal> GetBalance(Account account)
        {
            var response = GetInternalAccount(account.LoginName);
            if (!response.Success)
                return new DatabaseResponse<decimal>
                {
                    Success = false,
                    Message = response.Message
                };
            var internalAccount = response.Result!;
            return new DatabaseResponse<decimal>
            {
                Success = true,
                Result = internalAccount.Balance
            };
        }

        public DatabaseResponse<Transaction> GetLastTransaction(Account account)
        {
            var response = GetInternalAccount(account.LoginName);
            if (!response.Success)
                return new DatabaseResponse<Transaction>
                {
                    Success = false,
                    Message = response.Message
                };
            var internalAccount = response.Result!;
            var result = _transactions
                .Where(x =>
                    x.ToAccount?.AccountId == account.AccountId
                    || x.FromAccount?.AccountId == account.AccountId
                )
                .OrderByDescending(x => x.TransactionTime);
            if (result.Count() == 0)
                return new DatabaseResponse<Transaction> { Success = true };
            return new DatabaseResponse<Transaction> { Success = true, Result = result.First() };
        }

        public DatabaseResponse ApproveRiskyTransaction(
            Transaction transaction,
            string adminPassword
        )
        {
            if (_adminPassword != adminPassword)
                return new DatabaseResponse { Success = false, Message = "管理员密码错误。" };
            var responseFrom = GetInternalAccount(transaction.FromAccount!.LoginName);
            if (!responseFrom.Success)
                return new DatabaseResponse { Success = false, Message = responseFrom.Message };
            var internalFromAccount = responseFrom.Result!;

            var responseTo = GetInternalAccount(transaction.ToAccount!.LoginName);
            if (!responseTo.Success)
                return new DatabaseResponse { Success = false, Message = responseTo.Message };
            var internalToAccount = responseTo.Result!;

            internalFromAccount.Balance -= transaction.Amount;
            internalToAccount.Balance += transaction.Amount;
            transaction.TransactionTime = DateTime.Now;
            _transactions.Add(transaction);
            OnTransactionCompleted?.Invoke(transaction);
            OnRiskyTransactionApproved?.Invoke(transaction);
            return new DatabaseResponse { Success = true };
        }

        public DatabaseResponse DenyRiskyTransaction(Transaction transaction, string adminPassword)
        {
            if (_adminPassword != adminPassword)
                return new DatabaseResponse { Success = false, Message = "管理员密码错误。" };
            OnRiskyTransactionDenied?.Invoke(transaction);
            return new DatabaseResponse { Success = true };
        }

        public DatabaseResponse<List<AdminUserListItem>> GetAccountList(string password)
        {
            if (_adminPassword != password)
                return new DatabaseResponse<List<AdminUserListItem>>
                {
                    Success = false,
                    Message = "管理员密码错误。"
                };
            var result = _accounts
                .Select(x => new AdminUserListItem
                {
                    LoginName = x.Account.LoginName,
                    AccountId = x.Account.AccountId,
                    Name = x.Account.Name,
                    Pronouns = x.Account.Pronouns,
                    Balance = x.Balance
                })
                .ToList();
            return new DatabaseResponse<List<AdminUserListItem>>
            {
                Success = true,
                Result = result
            };
        }

        public DatabaseResponse<List<AccountTransactionListItem>> GetTransactionList(
            Account account,
            string password
        )
        {
            var response = GetInternalAccount(account.LoginName);
            if (!response.Success)
                return new DatabaseResponse<List<AccountTransactionListItem>>
                {
                    Success = false,
                    Message = response.Message
                };
            var internalAccount = response.Result!;
            if (internalAccount.Password != password)
                return new DatabaseResponse<List<AccountTransactionListItem>>
                {
                    Success = false,
                    Message = "密码错误。"
                };
            var result = _transactions
                .Where(x =>
                    x.FromAccount?.AccountId == account.AccountId
                    || x.ToAccount?.AccountId == account.AccountId
                )
                .ToList();
            return new DatabaseResponse<List<AccountTransactionListItem>>
            {
                Success = true,
                Result = result
                    .Select(x => new AccountTransactionListItem
                    {
                        Amount = x.Amount * (x.FromAccount?.AccountId == account.AccountId? -1 : 1),
                        Time = x.TransactionTime,
                        FromAccountName = x.FromAccount?.Name,
                        ToAccountName = x.ToAccount?.Name,
                        TransactionId = x.TransactionId,
                        FromAccountLoginName = x.FromAccount?.LoginName,
                        ToAccountLoginName = x.ToAccount?.LoginName,
                    })
                    .ToList()
            };
        }
    }
}
