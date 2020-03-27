using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Interop;

namespace TrueCalc
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        bool Check()
        {
            if (Number.Text != "0" && Number.Text[0] != 'E') return true; else return false;        
        }
        double a = 0;
        double b = 0;
        
        int count= 0;
        bool open = false;

        void Add_Digit(char a)
        {
            if(Check()) Number.Text += a;
        }
        private void Button_1_Click(object sender, EventArgs e)
        {

            Add_Digit('1');
        }

        private void Button_2_Click(object sender, EventArgs e)
        {
            Add_Digit('2');
        }

        private void Button_3_Click(object sender, EventArgs e)
        {
            Add_Digit('3');
        }
        private void Button_4_Click(object sender, EventArgs e)
        {
            Add_Digit('4');
        }
        private void Button_5_Click(object sender, EventArgs e)
        {
            Add_Digit('5');
        }
        private void Button_6_Click(object sender, EventArgs e)
        {
            Add_Digit('6');
        }
        private void Button_7_Click(object sender, EventArgs e)
        {
            Add_Digit('7');
        }
        private void Button_8_Click(object sender, EventArgs e)
        {
            Add_Digit('8');
        }
        private void Button_9_Click(object sender, EventArgs e)
        {
            Add_Digit('9');
        }
        private void Button_0_Click(object sender, EventArgs e)
        {
            Add_Digit('0');
        }
        private void Button_plus_Click(object sender, EventArgs e)
        {
            
            if (open)
            {
                Button_rov_Click(sender,e);
            }
            
            a = Convert.ToSingle(Number.Text);
            
           
            if (Number.Text[Number.Text.Length-1]>=48 && Number.Text[Number.Text.Length - 1] <= 57){
                Number.Text +='+';
            }
            else
            {
                Number.Text = Number.Text.Substring(0,Number.Text.Length-1) +'+' ;
            }

            open = true;
            
            count = 1;
        }
        private void Button_minus_Click(object sender, EventArgs e)
        {
            if (open)
            {
                Button_rov_Click(sender, e);
            }
            a = Convert.ToSingle(Number.Text);
            if (Number.Text[Number.Text.Length - 1] >= 48 && Number.Text[Number.Text.Length - 1] <= 57)
            {
                Number.Text += '-';
            }
            else
            {
                Number.Text = Number.Text.Substring(0, Number.Text.Length - 1) + '-';
            }
            count = 2;
            open = true;
            
        }
        private void Button_del_Click(object sender, EventArgs e)
        {
            if (open)
            {
                Button_rov_Click(sender, e);
            }
            
            a = Convert.ToSingle(Number.Text);
            if (Number.Text[Number.Text.Length - 1] >= 48 && Number.Text[Number.Text.Length - 1] <= 57)
            {
                Number.Text +='/';
            }
            else
            {
                Number.Text = Number.Text.Substring(0, Number.Text.Length - 1) + '/';
            }
            count = 3;
            open = true;
        }

        private void Button_um_Click(object sender, EventArgs e)
        {
            if (open)
            {
                Button_rov_Click(sender, e);
            }

            a = Convert.ToSingle(Number.Text);

            if (Number.Text[Number.Text.Length - 1] >= 48 && Number.Text[Number.Text.Length - 1] <= 57)
            {
                Number.Text +='*';
            }
            else
            {
                Number.Text = Number.Text.Substring(0, Number.Text.Length - 1) + '*';
            }

            count = 4;
            open = true;
            
        }
        private void Button_rov_Click(object sender, EventArgs e)
        {
            
            if(Number.Text[Number.Text.Length-1] >= 48 && 57 >= Number.Text[Number.Text.Length-1])
            {
                if(open) b = Convert.ToSingle(Number.Text.Substring(Convert.ToString(a).Length + 1));
                

                switch (count)
                {
                    case 1:
                        a+= b;
                        Number.Text = Convert.ToString(a);
                        break;
                    case 2:
                        a-=b;
                        Number.Text = Convert.ToString(a);
                        break;
                    case 3:
                        if (b != 0)
                        {
                            a /= b;
                            Number.Text = Convert.ToString(a);
                            break;
                        }
                        else
                        {
                            Number.Text = "ERROR";
                            break;
                        }
                        
                    case 4:
                        a*=b;
                        Number.Text = Convert.ToString(a);
                        break;
                }
               
            }
            else
            {
                Number.Text = Convert.ToString(a);
            }
            open = false;
        }
            
        private void Button_C_Click(object sender, EventArgs e)
        {
            Number.Text = "0";
            a = 0;
            b = 0;
            open = false;
            
           
        }
        private void Button_CE_Click(object sender, EventArgs e)
        {
            
            Number.Text = Convert.ToString(a);
            switch (count)
            {
                case 1:
                    Number.Text +='+';
                    break;
                case 2:
                    Number.Text +='-';
                    break;
                case 3:
                    Number.Text +='/';
                    break;
                case 4:
                    Number.Text +='*';
                    break;
            }
        }
        private void Button_point_Click(object sender, EventArgs e)
        {
            switch (Number.Text[Number.Text.Length - 1])
            {
                case '*':
                    Number.Text +="0,";
                    break;
                case '/':
                    Number.Text +="0,";
                    break;
                case '+':
                    Number.Text +="0,";
                    break;
                case '-':
                    Number.Text +="0,";
                    break;
            }
            if (!open) {
                a = Convert.ToSingle(Number.Text);
                if (a == Math.Truncate(a) && Number.Text[Number.Text.Length-1] != ',') { Number.Text += ','; }
            }
            else
            {
                b = Convert.ToSingle(Number.Text.Substring(Convert.ToString(a).Length + 1));
                if (b == Math.Truncate(b) && Number.Text[Number.Text.Length - 1] != ',')
                {
                    Number.Text += ',';
                }
            }
            
            


        }
        private void Form1_Load(object sender, EventArgs e)
        {
          
        }
       
          
        }
    }

