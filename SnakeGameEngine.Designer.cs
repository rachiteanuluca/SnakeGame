
namespace SnakeGame
{
    partial class SnakeGameEngine
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.startButton = new System.Windows.Forms.Button();
            this.snapButton = new System.Windows.Forms.Button();
            this.gameCanvas = new System.Windows.Forms.PictureBox();
            this.scoreLabel = new System.Windows.Forms.Label();
            this.highscoreLabel = new System.Windows.Forms.Label();
            this.gameTime = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gameCanvas)).BeginInit();
            this.SuspendLayout();
            // 
            // startButton
            // 
            this.startButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.startButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.startButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startButton.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.startButton.Location = new System.Drawing.Point(605, 23);
            this.startButton.Margin = new System.Windows.Forms.Padding(0);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(141, 74);
            this.startButton.TabIndex = 0;
            this.startButton.Text = "START";
            this.startButton.UseVisualStyleBackColor = false;
            this.startButton.Click += new System.EventHandler(this.StartGame);
            // 
            // snapButton
            // 
            this.snapButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.snapButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.snapButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.snapButton.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.snapButton.Location = new System.Drawing.Point(605, 108);
            this.snapButton.Margin = new System.Windows.Forms.Padding(0);
            this.snapButton.Name = "snapButton";
            this.snapButton.Size = new System.Drawing.Size(141, 85);
            this.snapButton.TabIndex = 1;
            this.snapButton.Text = "SNAP";
            this.snapButton.UseVisualStyleBackColor = false;
            this.snapButton.Click += new System.EventHandler(this.SnapGame);
            // 
            // gameCanvas
            // 
            this.gameCanvas.BackColor = System.Drawing.SystemColors.ControlLight;
            this.gameCanvas.Location = new System.Drawing.Point(12, 23);
            this.gameCanvas.Name = "gameCanvas";
            this.gameCanvas.Size = new System.Drawing.Size(580, 680);
            this.gameCanvas.TabIndex = 2;
            this.gameCanvas.TabStop = false;
            this.gameCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this.UpdateGameScreen);
            // 
            // scoreLabel
            // 
            this.scoreLabel.AutoSize = true;
            this.scoreLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.scoreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scoreLabel.Location = new System.Drawing.Point(600, 217);
            this.scoreLabel.Margin = new System.Windows.Forms.Padding(0);
            this.scoreLabel.Name = "scoreLabel";
            this.scoreLabel.Size = new System.Drawing.Size(102, 29);
            this.scoreLabel.TabIndex = 3;
            this.scoreLabel.Text = "Score: 0";
            // 
            // highscoreLabel
            // 
            this.highscoreLabel.AutoSize = true;
            this.highscoreLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.highscoreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.highscoreLabel.Location = new System.Drawing.Point(600, 258);
            this.highscoreLabel.Margin = new System.Windows.Forms.Padding(0);
            this.highscoreLabel.Name = "highscoreLabel";
            this.highscoreLabel.Size = new System.Drawing.Size(148, 29);
            this.highscoreLabel.TabIndex = 3;
            this.highscoreLabel.Text = "Highscore: 0";
            // 
            // gameTime
            // 
            this.gameTime.Interval = 40;
            this.gameTime.Tick += new System.EventHandler(this.GameTimerEvent);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(762, 728);
            this.Controls.Add(this.highscoreLabel);
            this.Controls.Add(this.scoreLabel);
            this.Controls.Add(this.gameCanvas);
            this.Controls.Add(this.snapButton);
            this.Controls.Add(this.startButton);
            this.Name = "Form1";
            this.Text = "Snake Game";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyIsDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyIsUp);
            ((System.ComponentModel.ISupportInitialize)(this.gameCanvas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button snapButton;
        private System.Windows.Forms.PictureBox gameCanvas;
        private System.Windows.Forms.Label scoreLabel;
        private System.Windows.Forms.Label highscoreLabel;
        private System.Windows.Forms.Timer gameTime;
    }
}

