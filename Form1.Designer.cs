namespace Wuthering_Waves_Fps_Unlocker
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            label1 = new Label();
            textBox1 = new TextBox();
            button1 = new Button();
            label2 = new Label();
            textBox2 = new TextBox();
            label3 = new Label();
            button2 = new Button();
            toolTip1 = new ToolTip(components);
            label4 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 43);
            label1.Name = "label1";
            label1.Size = new Size(92, 17);
            label1.TabIndex = 0;
            label1.Text = "数据库文件路径";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(110, 40);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(330, 23);
            textBox1.TabIndex = 1;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // button1
            // 
            button1.Location = new Point(446, 40);
            button1.Name = "button1";
            button1.Size = new Size(49, 23);
            button1.TabIndex = 2;
            button1.Text = "选择";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(11, 93);
            label2.Name = "label2";
            label2.Size = new Size(93, 17);
            label2.TabIndex = 3;
            label2.Text = "帧率(1-120FPS)";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(110, 90);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(48, 23);
            textBox2.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(164, 93);
            label3.Name = "label3";
            label3.Size = new Size(28, 17);
            label3.TabIndex = 5;
            label3.Text = "FPS";
            // 
            // button2
            // 
            button2.Location = new Point(420, 156);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 6;
            button2.Text = "修改";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // toolTip1
            // 
            toolTip1.AutomaticDelay = 100;
            toolTip1.AutoPopDelay = 0;
            toolTip1.InitialDelay = 100;
            toolTip1.ReshowDelay = 20;
            toolTip1.ToolTipIcon = ToolTipIcon.Info;
            toolTip1.ToolTipTitle = "以WeGame版为例";
            toolTip1.Popup += toolTip1_Popup;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 159);
            label4.Name = "label4";
            label4.Size = new Size(128, 17);
            label4.TabIndex = 7;
            label4.Text = "不会寻找数据库文件？";
            toolTip1.SetToolTip(label4, "一般在  %你的安装磁盘% \\WeGameApps\\rail_apps\\Wuthering Waves\\Client\\Saved\\LocalStorage下。\r\n有一个localstorage.db文件。官方启动器应该也大差不差");
            label4.Click += label4_Click_1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(542, 206);
            Controls.Add(label4);
            Controls.Add(button2);
            Controls.Add(label3);
            Controls.Add(textBox2);
            Controls.Add(label2);
            Controls.Add(button1);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "鸣潮120FPS解锁器";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBox1;
        private Button button1;
        private Label label2;
        private TextBox textBox2;
        private Label label3;
        private Button button2;
        private ToolTip toolTip1;
        private Label label4;
    }
}
