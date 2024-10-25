using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klotski.Controls
{
    internal class PanelMatrixItem : Panel
    {
        [Browsable(true)]
        [Category("Matrix")]
        [Description("The position of the panel in the matrix")]
        public Point Position { get; set; }
        public PanelMatrixItem() : base() { }
    }
}
