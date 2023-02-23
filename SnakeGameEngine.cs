using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Drawing.Imaging; //bitmap imaging for snapshoting

namespace SnakeGame
{
    public partial class SnakeGameEngine : Form
    {
        //variables
        private List<Circle> snakeBody = new List<Circle>();//snake body
        private Circle scorePoint = new Circle();//point/food for the snake
        //maximum size of the snake
        int maxWidth;
        int maxHeight;
        //score
        int score;
        int Highscore;
        //random coord for the point to be scored
        Random randCord = new Random();
        //directions
        bool goLeft, goRight, goUp, goDown;

        public SnakeGameEngine()
        {
            InitializeComponent();
            new Settings(); //init the static components of the settings class
        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {   //once the key is pressed but not released, change direction
            if (e.KeyCode == Keys.Left && Settings.directions != "right")
            {
                goLeft = true;
            }
            if (e.KeyCode == Keys.Right && Settings.directions != "left")
            {
                goRight = true;
            }
            if (e.KeyCode == Keys.Up && Settings.directions != "down")
            {
                goUp = true;
            }
            if (e.KeyCode == Keys.Down && Settings.directions != "up")
            {
                goDown = true;
            }
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {   
            //once the key is not pressed mark directions as false
            if(e.KeyCode == Keys.Left)
            {
                goLeft = false;
            }
            if(e.KeyCode == Keys.Right)
            {
                goRight = false;
            }
            if(e.KeyCode == Keys.Up)
            {
                goUp = false;
            }
            if(e.KeyCode == Keys.Down)
            {
                goDown  = false;
            }
        }

        private void StartGame(object sender, EventArgs e)
        {
            RestartGame(); //use the already established restart game function
        }

        private void SnapGame(object sender, EventArgs e)
        {
            //info to be added to the snapshot
            Label caption = new Label();
            caption.Text = "I scored " + score + " and my Highscore is " + Highscore;
            caption.Font = new Font("Ariel", 12, FontStyle.Bold);
            caption.ForeColor = Color.Red; //styling
            caption.AutoSize = false;
            caption.Width = gameCanvas.Width;
            caption.Height = 30;
            caption.TextAlign = ContentAlignment.MiddleCenter;
            gameCanvas.Controls.Add(caption);

            SaveFileDialog dialog = new SaveFileDialog();
            dialog.FileName = "Snake Game SnapShot " + score;
            dialog.DefaultExt = "jpg"; // file type default value
            dialog.Filter = "JPG Image File | *.jpg"; //filter any other file type
            dialog.ValidateNames = true; //validate any input for file to be saved

            if(dialog.ShowDialog()== DialogResult.OK)
            {
                int width = Convert.ToInt32(gameCanvas.Width);
                int height = Convert.ToInt32(gameCanvas.Height);
                Bitmap bmp = new Bitmap(width, height);
                gameCanvas.DrawToBitmap(bmp, new Rectangle(0,0,width,height));
                bmp.Save(dialog.FileName, ImageFormat.Jpeg);
                gameCanvas.Controls.Remove(caption);
            }
            
        }

        private void GameTimerEvent(object sender, EventArgs e)
        {
            //setting the directions
            if(goLeft)
            {
                Settings.directions = "left";
            }
            if(goRight)
            {
                Settings.directions = "right";
            }
            if(goUp)
            {
                Settings.directions = "up";
            }
            if(goDown)
            {
                Settings.directions = "down";
            }

            for(int i = snakeBody.Count - 1; i >= 0; i--)
            {
                if(i == 0)
                {
                    switch (Settings.directions)
                    {
                        case "left":
                            snakeBody[i].xCord--;
                            break;
                        case "right":
                            snakeBody[i].xCord++;
                            break;
                        case "up":

                            snakeBody[i].yCord--;
                            break;
                        case "down":
                            snakeBody[i].yCord++;
                            break;
                    }
                    if(snakeBody[i].xCord < 0){
                        snakeBody[i].xCord = maxWidth;
                    }
                    if (snakeBody[i].xCord > maxWidth)
                    {
                        snakeBody[i].xCord = 0;
                    }
                    if(snakeBody[i].yCord < 0){
                        snakeBody[i].yCord = maxHeight;
                    }
                    if (snakeBody[i].yCord > maxHeight)
                    {
                        snakeBody[i].yCord = 0;
                    }
                    if(snakeBody[i].xCord == scorePoint.xCord && snakeBody[i].yCord == scorePoint.yCord)
                    {
                        IncreaseScore();
                    }
                    for(int j = 1;  j < snakeBody.Count; j++)
                    {
                        if (snakeBody[i].xCord == snakeBody[j].xCord && snakeBody[i].yCord == snakeBody[j].yCord)
                            GameOver(); 
                    }
                }
                else
                {
                    snakeBody[i].xCord = snakeBody[i - 1].xCord;
                    snakeBody[i].yCord = snakeBody[i - 1].yCord;
                }
            }
            gameCanvas.Invalidate();

        }

        private void UpdateGameScreen(object sender, PaintEventArgs e)
        {
            Graphics canvas = e.Graphics;

            Brush snakeColor; //coloring the snake

            for (int i = 0; i < snakeBody.Count; i++)
            {
                if (i == 0)
                {
                    snakeColor = Brushes.Black;
                }
                else
                {
                    snakeColor = Brushes.DarkGreen;
                }
                canvas.FillEllipse(snakeColor, new Rectangle
                    (
                    snakeBody[i].xCord * Settings.width,
                    snakeBody[i].yCord * Settings.height,
                    Settings.width, Settings.height
                    ));
            }
            canvas.FillEllipse(Brushes.DarkRed, new Rectangle
                (
                scorePoint.xCord * Settings.width,
                scorePoint.yCord * Settings.height,
                Settings.width, Settings.height
                ));
        }

        private void RestartGame()
        {
            maxWidth = gameCanvas.Width / Settings.width - 1;
            maxHeight = gameCanvas.Height / Settings.height - 1;

            snakeBody.Clear(); //restart the body of the snake;

            //buttons must be unfocasable so that controls work
            startButton.Enabled = false;
            snapButton.Enabled = false;
            //set the initial conditions of the game
            score = 0;
            scoreLabel.Text = "Score: " + score;
            //create the "head" of the snake
            Circle head = new Circle { xCord = 10, yCord = 5 };
            snakeBody.Add(head); //index 0 == head of the snake

            for (int i = 0; i < 10; i++)
            {
                Circle bodyPart = new Circle();
                snakeBody.Add(bodyPart);
            }
            //randomly position a new point to be scored
            scorePoint = new Circle { xCord = randCord.Next(2, maxWidth), yCord = randCord.Next(2, maxHeight) };
       
            gameTime.Start();
        }

        private void IncreaseScore()
        {
            score++;
            scoreLabel.Text = "Score: " + score;

            //increase the snake len
            Circle bodyPart = new Circle
            {
                xCord = snakeBody[snakeBody.Count - 1].xCord,
                yCord = snakeBody[snakeBody.Count - 1].yCord
            };
            snakeBody.Add(bodyPart);
            //new point to be scored
            scorePoint = new Circle { xCord = randCord.Next(2, maxWidth), yCord = randCord.Next(2, maxHeight) };
        }

        private void GameOver()
        {
            gameTime.Stop();
            startButton.Enabled = true;
            snapButton.Enabled = true;

            if(score > Highscore)
            {
                Highscore = score;
                highscoreLabel.Text = "Highscore: " + Highscore;
                highscoreLabel.ForeColor = Color.Red;
            }
        }
    }
}
