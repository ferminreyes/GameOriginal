﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace Game
{
    public partial class Form1 : Form
    {

        GameBoard gb;

        public Form1()
        {
            InitializeComponent();

            gb = new GameBoard();   
        }

        private void Form1_Load(object sender, EventArgs e)
        {
          //  Element element = new Element(0, 0, @"images\dirt.bmp");
          //  element.Draw(this);

         //   gb.draw_board(this);
           
            

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {  
               
              gb.draw_board(this); 
              gb.next.Draw(this);
        }

        private void Form1_Move(object sender, EventArgs e)
        {
      
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
           

            Sprite selected = gb.get_selected(e.X, e.Y);

            if (selected == null)
            {
                this.label1.Text = "NADA";
                this.label4.Text = "NADA";
            }
            else
            {
                this.label1.Text = selected.i.ToString();
                this.label4.Text = selected.j.ToString();
                if (selected.current == Sprite.Type.empty)
                {
                    selected.current = gb.next.current;
                    gb.update();
                    gb.getNext().Draw(this);
                    gb.draw_board(this);
                }   

             }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            int time2;
             gb= new GameBoard();
             do 
                {
                   for (time2 = time; time < 60; time ++ )
                   {
                      time++;
                   }

                }
             while (time == 60);
             timer1.Start();

        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (time == 0)
            {
                timer1.Stop();
                time = 60;
                MessageBox.Show("GAME OVER");
                timer1.Start();
            }
            else
            {
                time = time - 1;
                label2.Text = "TIME: " + time;
            }
        }
    }
}
