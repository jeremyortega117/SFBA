
namespace SimpleFamilyBudgetApp_v_1._0._0
{
    partial class User_Editor
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
            this.listViewUserEditor = new System.Windows.Forms.ListView();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.textBoxFirstName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxLastName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxMI = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxUsername = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxUserPass = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // listViewUserEditor
            // 
            this.listViewUserEditor.Dock = System.Windows.Forms.DockStyle.Top;
            this.listViewUserEditor.HideSelection = false;
            this.listViewUserEditor.Location = new System.Drawing.Point(0, 0);
            this.listViewUserEditor.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listViewUserEditor.Name = "listViewUserEditor";
            this.listViewUserEditor.Size = new System.Drawing.Size(579, 264);
            this.listViewUserEditor.TabIndex = 0;
            this.listViewUserEditor.UseCompatibleStateImageBehavior = false;
            this.listViewUserEditor.SelectedIndexChanged += new System.EventHandler(this.listViewUserEditor_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(199, 470);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(201, 54);
            this.button1.TabIndex = 1;
            this.button1.Text = "Add User";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(199, 593);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(201, 54);
            this.button2.TabIndex = 2;
            this.button2.Text = "Delete Selected User";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(199, 532);
            this.button3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(201, 54);
            this.button3.TabIndex = 3;
            this.button3.Text = "Update Selected User";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // textBoxFirstName
            // 
            this.textBoxFirstName.Location = new System.Drawing.Point(199, 297);
            this.textBoxFirstName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxFirstName.MaxLength = 30;
            this.textBoxFirstName.Name = "textBoxFirstName";
            this.textBoxFirstName.Size = new System.Drawing.Size(200, 22);
            this.textBoxFirstName.TabIndex = 4;
            this.textBoxFirstName.TextChanged += new System.EventHandler(this.Text_Changed);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(104, 300);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "First Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(103, 332);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "Last Name:";
            // 
            // textBoxLastName
            // 
            this.textBoxLastName.Location = new System.Drawing.Point(199, 329);
            this.textBoxLastName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxLastName.MaxLength = 30;
            this.textBoxLastName.Name = "textBoxLastName";
            this.textBoxLastName.Size = new System.Drawing.Size(200, 22);
            this.textBoxLastName.TabIndex = 6;
            this.textBoxLastName.TextChanged += new System.EventHandler(this.textBoxLastName_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(93, 368);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 16);
            this.label3.TabIndex = 9;
            this.label3.Text = "Middle Initial:";
            // 
            // textBoxMI
            // 
            this.textBoxMI.Location = new System.Drawing.Point(199, 364);
            this.textBoxMI.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxMI.MaxLength = 1;
            this.textBoxMI.Name = "textBoxMI";
            this.textBoxMI.Size = new System.Drawing.Size(200, 22);
            this.textBoxMI.TabIndex = 8;
            this.textBoxMI.TextChanged += new System.EventHandler(this.textBoxMI_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(100, 401);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 16);
            this.label4.TabIndex = 10;
            this.label4.Text = "User Name:";
            // 
            // textBoxUsername
            // 
            this.textBoxUsername.Location = new System.Drawing.Point(199, 398);
            this.textBoxUsername.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxUsername.MaxLength = 30;
            this.textBoxUsername.Name = "textBoxUsername";
            this.textBoxUsername.Size = new System.Drawing.Size(200, 22);
            this.textBoxUsername.TabIndex = 11;
            this.textBoxUsername.TextChanged += new System.EventHandler(this.textBoxUsername_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(107, 433);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 16);
            this.label5.TabIndex = 12;
            this.label5.Text = "User Pass:";
            // 
            // textBoxUserPass
            // 
            this.textBoxUserPass.Location = new System.Drawing.Point(199, 428);
            this.textBoxUserPass.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxUserPass.MaxLength = 30;
            this.textBoxUserPass.Name = "textBoxUserPass";
            this.textBoxUserPass.Size = new System.Drawing.Size(200, 22);
            this.textBoxUserPass.TabIndex = 13;
            // 
            // User_Editor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(579, 686);
            this.Controls.Add(this.textBoxUserPass);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxUsername);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxMI);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxLastName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxFirstName);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listViewUserEditor);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "User_Editor";
            this.Text = "User_Editor";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CloseBehavior);
            this.Load += new System.EventHandler(this.User_Editor_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listViewUserEditor;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textBoxFirstName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxLastName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxMI;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxUsername;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxUserPass;
    }
}