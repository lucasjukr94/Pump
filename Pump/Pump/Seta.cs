using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pump
{
    public class Seta : Control
    {
        public Seta(int x, int y, int width, int height, int direcao)
        {
            this.x = x;
            this.y = y;
            this.direcao = direcao;
            Width = width;
            Height = height;
        }

        public int x { get; set; }
        public int y { get; set; }

        public int direcao { get; set; }

        public SolidBrush brush { get; set; }
    }
}
