> 除非特殊标明, 否则基于 [https://source.dot.net](https://source.dot.net/)

## `System.Object`
1.	其 `ToString()` 的声明前的修饰符是什么?
> `public virtual`

2.	其两个 `Equals()` 函数是什么关系, 与 `ReferenceEquals()` 有没有差别?
> - `public virtual bool Equals(object? obj)` 是虚函数. 调用方法 `A.Equals(B)`, `public static bool Equals(object? objA, object? objB)` 是静态函数, 调用方法 `Object.Equals(A, B)`。
> - 当 objA 和 objB 不满足 `objA == objB`, 且 `objA` 和 `objB` 均不是 `null` 时, `public static bool Equals(object? objA, object? objB)` 会执行 objA.Equals(objB).
> - `public static bool ReferenceEquals(object? objA, object? objB)` 是静态函数, 它会直接返回 `objA == objB` 这个表达式的值.

3.	其 `GetHashCode()` 前面有个什么修饰语?
> `public virtual`

4.	有没有 `Clone()` 函数?
> 无.

5.	其构造函数做了什么? 有没有写析构函数?
> 空的构造函数. 空的析构函数.

## `System.Type`
6.	它的构造方法前面有什么修饰符?
`public override`

7.	为什么说我们不能 `new Type()`?
> `Type` 是抽象类, 不能实例化。

8.	`GetFields()`, `GetMethods()`, `GetProperties()`, `GetEvents()` 各有什么作用?
> - `GetFields()` 返回当前类型的所有公开字段.
> - `GetMethods()` 返回当前类型的所有公开方法.
> - `GetProperties()` 返回当前类型的所有公开属性.
> - `GetEvents()` 返回当前类型的所有公开事件.


## `System.String`
9.	`String` 可以继承吗?
> 不能. `sealed`

10.	从哪里可以看出 `String` 是可以比较、可以克隆的?
> 继承了 `IComparable` 和 `ICloneable` 接口.

11.	`Join()` 函数使用了什么样的保卫语句?
> 如果传入 `null` 直接抛出异常, 如果传入数组为空直接返回空字符串, 如果传入数组长度为 1, 直接返回数组的第一个元素与空字符串 `null` 合并之后的结果.

12.	`Join()` 方法中使用了 `StringBuilder` 对象, 为什么不要在多次循环中使用 `+=`?
> 每次使用 `+=` 都会导致内存分配, 导致运行效率下降, 内存碎片化. 而使用 `StringBuilder` 则可以减少内存的频繁分配.

13.	为什么说 `String` 是 immutable 的?其 `Replace`、`Append`、`Trim`等方法是否改变了这个字符串自己?
> `Replace`, `Append`, `Trim` 等方法实例化一个新字符串对象后返回, 而不是改变原来的字符串对象。

14.	`ToUpper` 中如何将字符变大写, 为何该函数要用 `unsafe` 的指针?
> 先对 Ascii 字符转换大小写, 然后根据指定的 CulturalInfo 转换其他字符. 读取字符时, 使用了 `Unsafe.ReadUnaligned` 一次读取两个字符避免非 Ascii 字符被截断.

15.	`Equals` 方法是判断内容相等还是引用相等?为什么说字符串的 `==` 比较的是内容相等?`compareTo` 是比较什么?
> `Equals` 方法判断内容相等, `==` 调用 `Equals` 方法. `CompareTo` 对字符串进行逐字比较直到找到在 `comparisonType` 条件下不同的字符, 根据 `comparisonType` 返回两个字符的差值.

16.	字符串中如何定义索引器的?
~~~csharp
[IndexerName("Chars")]
public char this[int index]
{
    [Intrinsic]
    get
    {
        if ((uint)index >= (uint)_stringLength)
            ThrowHelper.ThrowIndexOutOfRangeException();
        return Unsafe.Add(ref _firstChar, (nint)(uint)index /* force zero-extension */);
    }
}
~~~

17.	`IsNullOrWhiteSpace`是什么含义?
> 参数字符串不为 `null` 而且所有字符不是空白字符.

18.	`GetHashCode` 方法 `override` 是谁的方法, 它使用指针有什么好处?
> - `Object.GetHashCode`
> - 使得函数能够对字节进行深度操作.

19.	`ToDouble()` 调用了什么类的什么方法?
> ??

## `System.Text.StringBuilder`
20.	`StringBuilder` 的初始内存是多少字符?
> 16.

21.	`Capacity` 属性的 `get` 和 `set` 方法有什么用, `set` 是在原来的基础上扩展多少?
> - `get` 返回当前 chunk 大小 + chunk 在字符串中的 offset,
> - `set` 初始化一个 char[], 长度 = 新 capacity - offset, 并将原字符串的字符复制到新 char[], 将内部的 char[] 指向新 char[], 并更新 chunk 大小.
> - `int newBlockLength = Math.Max(minBlockCharCount, Math.Min(Length, MaxChunkSize))` 计算新 chunk 大小. `minBlockCharCount` 新增大小, `Length` 当前长度, `MaxChunkSize = 8000`.

22.	`Append()`、`Remove()`等方法的返回值是什么, 这有什么好处?
> - 返回 `StringBuilder` 对象本身, 便于链式调用.

## `System.Double`
23.	`Double` 是 `struct` 还是 `class`? 它实现了哪些接口?
> - `struct`
> - 实现了
>   - `IComparable`,
>   - `IConvertible`,
>   - `ISpanFormattable`,
>   - `IComparable<double>`,
>   - `IEquatable<double>`,
>   - `IBinaryFloatingPointIeee754<double>`,
>   - `IMinMaxValue<double>`,
>   - `IUtf8SpanFormattable`,
>   - `IBinaryFloatParseAndFormatInfo<double>`.

24.	它里面有几个字段? 前面用了什么修饰词?
25.	其常数 `MaxValue` 前面用了什么修饰词, 其值是多少?
~~~csharp
private readonly double m_value; // Do not rename (binary serialization)
 
//
// Public Constants
//
public const double MinValue = -1.7976931348623157E+308;
public const double MaxValue = 1.7976931348623157E+308;
 
// Note Epsilon should be a double whose hex representation is 0x1
// on little endian machines.
public const double Epsilon = 4.9406564584124654E-324;
public const double NegativeInfinity = (double)-1.0 / (double)(0.0);
public const double PositiveInfinity = (double)1.0 / (double)(0.0);
public const double NaN = (double)0.0 / (double)0.0;
 
/// <summary>Represents the additive identity (0).</summary>
internal const double AdditiveIdentity = 0.0;
 
/// <summary>Represents the multiplicative identity (1).</summary>
internal const double MultiplicativeIdentity = 1.0;
 
/// <summary>Represents the number one (1).</summary>
internal const double One = 1.0;
 
/// <summary>Represents the number zero (0).</summary>
internal const double Zero = 0.0;
 
/// <summary>Represents the number negative one (-1).</summary>
internal const double NegativeOne = -1.0;
 
/// <summary>Represents the number negative zero (-0).</summary>
public const double NegativeZero = -0.0;
 
/// <summary>Represents the natural logarithmic base, specified by the constant, e.</summary>
/// <remarks>Euler's number is approximately 2.7182818284590452354.</remarks>
public const double E = Math.E;
 
/// <summary>Represents the ratio of the circumference of a circle to its diameter, specified by the constant, PI.</summary>
/// <remarks>Pi is approximately 3.1415926535897932385.</remarks>
public const double Pi = Math.PI;
 
/// <summary>Represents the number of radians in one turn, specified by the constant, Tau.</summary>
/// <remarks>Tau is approximately 6.2831853071795864769.</remarks>
public const double Tau = Math.Tau;
 
//
// Constants for manipulating the private bit-representation
//
 
internal const ulong SignMask = 0x8000_0000_0000_0000;
internal const int SignShift = 63;
internal const byte ShiftedSignMask = (byte)(SignMask >> SignShift);
 
internal const ulong BiasedExponentMask = 0x7FF0_0000_0000_0000;
internal const int BiasedExponentShift = 52;
internal const int BiasedExponentLength = 11;
internal const ushort ShiftedExponentMask = (ushort)(BiasedExponentMask >> BiasedExponentShift);
 
internal const ulong TrailingSignificandMask = 0x000F_FFFF_FFFF_FFFF;
 
internal const byte MinSign = 0;
internal const byte MaxSign = 1;
 
internal const ushort MinBiasedExponent = 0x0000;
internal const ushort MaxBiasedExponent = 0x07FF;
 
internal const ushort ExponentBias = 1023;
 
internal const short MinExponent = -1022;
internal const short MaxExponent = +1023;
 
internal const ulong MinTrailingSignificand = 0x0000_0000_0000_0000;
internal const ulong MaxTrailingSignificand = 0x000F_FFFF_FFFF_FFFF;
 
internal const int TrailingSignificandLength = 52;
internal const int SignificandLength = TrailingSignificandLength + 1;
 
// Constants representing the private bit-representation for various default values
 
internal const ulong PositiveZeroBits = 0x0000_0000_0000_0000;
internal const ulong NegativeZeroBits = 0x8000_0000_0000_0000;
 
internal const ulong EpsilonBits = 0x0000_0000_0000_0001;
 
internal const ulong PositiveInfinityBits = 0x7FF0_0000_0000_0000;
internal const ulong NegativeInfinityBits = 0xFFF0_0000_0000_0000;
 
internal const ulong SmallestNormalBits = 0x0010_0000_0000_0000;
~~~

26.	`CompareTo` 什么情况下返回 `-1`, `0` 及 `1` ?
> 考虑 a.CompareTo(b) 的返回值:
> - 如果 a, b 均为有效值, 则比较它们的大小, a < b => -1, a = b => 0, a > b => 1,
> - 如果 b 为 null, 返回 1,
> - 如果 a 为 NaN:
>   - 如果 b 为 NaN, 返回 0,
>   - 如果 b 为有效值, 返回 -1,
>   - 如果 b 为 null, 返回 1.

27.	`Equals` 是 `override` 谁的方法?两个 `NaN` 是否相等?是否 `==`（请编码试一下）?
> - `Object.Equals`,
> - 相等,
> - 不 `==`.

28.	如何实现 `==` 的运算符重载的?
> 好像没有重载?

29.	`GetHashCode` 是如何计算的?
~~~csharp
public override int GetHashCode()
{
    ulong bits = BitConverter.DoubleToUInt64Bits(m_value);
 
    if (IsNaNOrZero(m_value))
    {
        // Ensure that all NaNs and both zeros have the same hash code
        bits &= PositiveInfinityBits;
    }
 
    return unchecked((int)bits) ^ ((int)(bits >> 32));
}
~~~

## `System.Convert`
30.	`Convert` 类前面为什么加个 `static`?
> 无需创建实例, 直接调用 `Convert` 上的方法.

31.	`ToDouble(int value)` 及 `ToDouble(string value)` 内部分别调用了什么方法?
> - `return value;`
> - `double.Parse(value);`

## `System.Math`
32.	`Abs(short)` 什么情况下会抛出导常?
> 传入的 short 值是 `short.MinValue`

33.	举几个方法是 `extern` 的方法。
> 所有涉及三角函数计算的方法皆标记为 `extern`.

## `System.Random`
34.	不带参数的构造函数, 它用什么进行了初始化?
~~~csharp
public Random() =>
// With no seed specified, if this is the base type, we can implement this however we like.
// If it's a derived type, for compat we respect the previous implementation, so that overrides
// are called as they were previously.
_impl = GetType() == typeof(Random) ? new XoshiroImpl() : new CompatDerivedImpl(this);
~~~

35.	从 `Next()` 来看为什么说它是伪随机?
> 确定的算法在很长的周期后会生成相同的随机数序列.

## `System.Array`
36.	它使用了一个什么内部类?
> 这个没找到 :-(

37.	`SorterGenericArray()` 来看它使用哪两种主要的算法?
> - .NET Framework: `IntrospectiveSort()` 和 `DepthLimitedQuickSort()`
> - .NET: `IntrospectiveSort()`

## `List<T>`
38.	从 `EnsureCapacity()` 可以看出每次容量增加多少倍?
> 2 倍.

## `Stack<T>`
39.	`Push()` 与 `Pop()` 进行了什么操作?
> - `Stack<T>` 内部使用 `Array` 实现,
> - `Push()` 检查当前内部的 `Array` 长度能否容纳新的元素, 如果可以, 将元素追加到 `Array` 尾部, 否则, 调用 `Array.Resize()` 创建并修改引用到新 `Array`, 复制已有值并追加新元素;
> - `Pop()` 将内部 `_size` 减一, 并返回最后一个元素, 如果这个元素是引用类型, 将 `Array` 中该元素原有的位置置为 `default`.

## `Hashtable`
40.	`Hashtable` 是如何定义索引器的?
~~~csharp
// Returns the value associated with the given key. If an entry with the
// given key is not found, the returned value is null.
//
public virtual object? this[object key]
{
    get
    {
        ArgumentNullException.ThrowIfNull(key);
 
        // Take a snapshot of buckets, in case another thread does a resize
        Bucket[] lbuckets = _buckets;
        uint hashcode = InitHash(key, lbuckets.Length, out uint seed, out uint incr);
        int ntry = 0;
 
        Bucket b;
        int bucketNumber = (int)(seed % (uint)lbuckets.Length);
        do
        {
            int currentversion;
 
            // A read operation on hashtable has three steps:
            //        (1) calculate the hash and find the slot number.
            //        (2) compare the hashcode, if equal, go to step 3. Otherwise end.
            //        (3) compare the key, if equal, go to step 4. Otherwise end.
            //        (4) return the value contained in the bucket.
            //     After step 3 and before step 4. A writer can kick in a remove the old item and add a new one
            //     in the same bucket. So in the reader we need to check if the hash table is modified during above steps.
            //
            // Writers (Insert, Remove, Clear) will set 'isWriterInProgress' flag before it starts modifying
            // the hashtable and will clear the flag when it is done.  When the flag is cleared, the 'version'
            // will be increased.  We will repeat the reading if a writer is in progress or done with the modification
            // during the read.
            //
            // Our memory model guarantee if we pick up the change in bucket from another processor,
            // we will see the 'isWriterProgress' flag to be true or 'version' is changed in the reader.
            //
            SpinWait spin = default;
            while (true)
            {
                // this is volatile read, following memory accesses can not be moved ahead of it.
                currentversion = _version;
                b = lbuckets[bucketNumber];
 
                if (!_isWriterInProgress && (currentversion == _version))
                    break;
 
                spin.SpinOnce();
            }
 
            if (b.key == null)
            {
                return null;
            }
            if (((b.hash_coll & 0x7FFFFFFF) == hashcode) &&
                KeyEquals(b.key, key))
                return b.val;
            bucketNumber = (int)(((long)bucketNumber + incr) % (uint)lbuckets.Length);
        } while (b.hash_coll < 0 && ++ntry < lbuckets.Length);
        return null;
    }
 
    set => Insert(key, value, false);
}
~~~

## `WebClient`
41.	从 `GetWebRequest()` 来看, 其 `WebClient` 与 `WebRequest` 是什么关系?
> `WebClient` 在构建 `WebRequest` 时, 会自动设置 `WebRequest` 的部分首部 (User-Agent, Content-Type, etc.) 和属性 (Credentials, Method, etc.),

42.	`DownloadString()` 中调用了 `GetStringUsingEncoding()`, 后者是如何猜测网页的字符编码的?
> - 首先, 尝试从响应 Content-Type HTTP 首部读取编码信息,
> - 否则, 尝试将响应数据的头部与 `s_knownEncodings` 列表 (`{ Encoding.UTF8, Encoding.UTF32, Encoding.Unicode, Encoding.BigEndianUnicode }`) 中的 BOM 匹配, 如果匹配成功, 则使用对应的编码,
> - 否则, 使用 `Encoding.Default`, 或通过 `Encoding` 属性指定的默认值.