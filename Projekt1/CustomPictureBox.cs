using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projekt1
{
    
        class CustomPictureBox : PictureBox
        {
      
        public CustomPictureBox(IContainer container)
            {
            
            container.Add(this);

            }
            Point point;
            protected override void OnMouseDown(MouseEventArgs e)
            {
                point = e.Location;
                base.OnMouseDown(e);
            }
        
        protected override void OnMouseMove(MouseEventArgs e)
            {
                if (e.Button == MouseButtons.Left)
                {
                    this.Left += e.X - point.X;
                
                    this.Top += e.Y - point.Y;
                
                }
                base.OnMouseMove(e);
            }
        
        private void InitializeComponent()
            {
                ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
                this.SuspendLayout();
                ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
                this.ResumeLayout(false);

            }

            private void pictureBox1_Click(object sender, EventArgs e)
            {

            }
        }
    
}
