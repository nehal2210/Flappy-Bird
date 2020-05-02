using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib; // media player library
namespace f_b
{
    public partial class Form1 : Form
    {
        int hi_score;
        int score = 0; // variables
        Random r = new Random();

        // medias player objects for sound
        WindowsMediaPlayerClass play_out = new WindowsMediaPlayerClass();
         WindowsMediaPlayerClass play_point = new WindowsMediaPlayerClass();
         WindowsMediaPlayerClass play_wing = new WindowsMediaPlayerClass();
        WindowsMediaPlayerClass play_die = new WindowsMediaPlayerClass();
        WindowsMediaPlayerClass play_swooshing = new WindowsMediaPlayerClass();


        public Form1()
        {
            InitializeComponent();

            /* Buffered graphics require that the updated graphics data is first written to a buffer.
             * The data in the graphics buffer is then quickly written to displayed surface memory.
             * The relatively quick switch of the displayed graphics memory typically reduces the flicker that can otherwise occur.
                
             */
            this.DoubleBuffered = true;
            
            gover.Visible = false;
            play_point.URL = "point.wav";
            play_out.URL = "hit.wav";
            play_wing.URL = "wing.wav";
            play_die.URL = "die.wav";
            play_swooshing.URL = "swooshing.wav";

            play_swooshing.stop();
            play_wing.stop();
            play_die.stop();
            play_out.stop();
            play_point.stop();
            timer1.Enabled = false;
            timer2.Enabled = false;
            Start.Visible = true;
            Start.Enabled = true;
            bird.Enabled = false;

             hi_score = Convert.ToInt32(System.IO.File.ReadAllText("highscore.txt"));
            high_score.Text = Convert.ToString("High Score : " + hi_score.ToString());
            
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int size_hurdle = r.Next(0, 25);

            movtree(7);
            movhurdles(2,size_hurdle);
            gameover();
            
        }
        void movtree(int speed)
        {

            if (t1.Left >= -74)
            {
                t1.Left += -speed;
                
            }
            else
            {
                t1.Left = 800;
            }
            if (t2.Left >= -74)
            {
                t2.Left += -speed;

            }
            else
            {
                t2.Left = 800;
            }
            if (t3.Left >= -74)
            {
                t3.Left += -speed;

            }
            else
            {
                t3.Left = 800;
            }
        }

        void movhurdles(int speed, int size_hurdle)
        {

            if (h1.Left >= -79)
            {
                h1.Left += -speed;

            }
            else
            {
                h1.Left = 800;
                //h1.Height = r.Next(100,150);
             //   h1.Top += size_hurdle;

                if (size_hurdle %2!=0)
                {
                    h1.Height += size_hurdle;

                }
                else
                {
                    h1.Height += -size_hurdle;

                }

            }

            if (h2.Left >= -79)
            {
                h2.Left += -speed;

            }
            else
            {
                h2.Left = 800;
                //h2.Height = r.Next(100, 156);
                if (size_hurdle!=0)
                {
                    h2.Top += size_hurdle;
                    //h2.Height += -size_hurdle;
                }
                else
                {
                    h2.Top += -size_hurdle;
                    h2.Height += size_hurdle;
                }
            }

            if (h3.Left >= -79)
            {
                h3.Left += -speed;

            }
            else
            {
                h3.Left = 800;
                //  h3.Height = r.Next(100, 170);
                if (size_hurdle %2==0)
                {
                    h3.Height += size_hurdle;

                }
                else
                {
                    h3.Height += -size_hurdle;

                }

            }

            if (h4.Left >= -79)
            {
                h4.Left += -speed;
                

            }
            else
            {
                // h4.Height = r.Next(100, 170);
                h4.Left = 800;
                if (size_hurdle%2==0)
                {
                    h4.Top += size_hurdle;
                   // h4.Height += -size_hurdle;
                }
                else
                {
                    h4.Top += -size_hurdle;
                    h4.Height += size_hurdle;

                }

            }

        }







        private void timer2_Tick(object sender, EventArgs e)
        {
            if (bird.Top <= 296)
            {
                bird.Top += 1;
                play_swooshing.play();
            }

          
            if ((h1.Location.X == 0 && h2.Location.X == 0) || (h3.Location.X  == 0 && h4.Location.X == 0))
            {
                score += 1;
                points.Text = score.ToString();
                play_point.play();


            }
        }

                   private void form_keydown(object sender, PreviewKeyDownEventArgs e)
                    {

                    }
                    void gameover()
                    {
                        if (bird.Bounds.IntersectsWith(h1.Bounds)||(bird.Bounds.IntersectsWith(h2.Bounds))||(bird.Bounds.IntersectsWith(h3.Bounds))||(bird.Bounds.IntersectsWith(h4.Bounds)) ||bird.Top==296)
                        {
                             play_out.play();
                             play_die.play();

                            timer1.Enabled = false;
                            timer2.Enabled = false;
                            gover.Visible = true;
                            Start.Visible = true;
                            Start.Enabled = true;
          
                // bird.Enabled = false;// kusch nhi ho rha
                if (score > hi_score)
                {
                    System.IO.File.WriteAllText("highscore.txt",score.ToString());

                }

            }
        }
                    private void Form1_KeyDown(object sender, KeyEventArgs e)
                    {
            if (timer1.Enabled==true)
            {
                if (e.KeyCode == Keys.Up)
                {
                    bird.Top += -40;
                    play_wing.play();
                }

            }


        }

                   




        private void Start_Click(object sender, EventArgs e)
        {
            
            if (gover.Visible==true)
            {
                Application.Restart();

            }
            else
            {
                timer1.Enabled = true;
                timer2.Enabled = true;
                Start.Visible = false;
                Start.Enabled = false;
                bird.Enabled = true;
               

            }
        }



    }
            }
