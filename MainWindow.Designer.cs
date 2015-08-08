namespace RedditWallpapers
{
    partial class MainWindow
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
            this.resultsList = new System.Windows.Forms.ListView();
            this.searchTermInput = new System.Windows.Forms.TextBox();
            this.subChooserCombo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.listingTypeCombo = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.setWallpaperButton = new System.Windows.Forms.Button();
            this.getResultsButton = new System.Windows.Forms.Button();
            this.Titles = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // resultsList
            // 
            this.resultsList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Titles});
            this.resultsList.FullRowSelect = true;
            this.resultsList.Location = new System.Drawing.Point(300, 12);
            this.resultsList.MultiSelect = false;
            this.resultsList.Name = "resultsList";
            this.resultsList.Size = new System.Drawing.Size(533, 361);
            this.resultsList.TabIndex = 0;
            this.resultsList.UseCompatibleStateImageBehavior = false;
            // 
            // searchTermInput
            // 
            this.searchTermInput.Location = new System.Drawing.Point(85, 29);
            this.searchTermInput.Name = "searchTermInput";
            this.searchTermInput.Size = new System.Drawing.Size(182, 20);
            this.searchTermInput.TabIndex = 1;
            this.searchTermInput.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // subChooserCombo
            // 
            this.subChooserCombo.FormattingEnabled = true;
            this.subChooserCombo.Items.AddRange(new object[] {
            "Earthporn",
            "Wallpapers"});
            this.subChooserCombo.Location = new System.Drawing.Point(85, 55);
            this.subChooserCombo.Name = "subChooserCombo";
            this.subChooserCombo.Size = new System.Drawing.Size(182, 21);
            this.subChooserCombo.TabIndex = 2;
            this.subChooserCombo.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Search Term";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "SubReddit";
            // 
            // listingTypeCombo
            // 
            this.listingTypeCombo.FormattingEnabled = true;
            this.listingTypeCombo.Items.AddRange(new object[] {
            "Top",
            "Hot"});
            this.listingTypeCombo.Location = new System.Drawing.Point(85, 82);
            this.listingTypeCombo.Name = "listingTypeCombo";
            this.listingTypeCombo.Size = new System.Drawing.Size(182, 21);
            this.listingTypeCombo.TabIndex = 5;
            this.listingTypeCombo.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(41, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Listing";
            // 
            // setWallpaperButton
            // 
            this.setWallpaperButton.Location = new System.Drawing.Point(192, 350);
            this.setWallpaperButton.Name = "setWallpaperButton";
            this.setWallpaperButton.Size = new System.Drawing.Size(97, 23);
            this.setWallpaperButton.TabIndex = 8;
            this.setWallpaperButton.Text = "Set Wallpaper";
            this.setWallpaperButton.UseVisualStyleBackColor = true;
            this.setWallpaperButton.Click += new System.EventHandler(this.setWallpaperButton_Click);
            // 
            // getResultsButton
            // 
            this.getResultsButton.Location = new System.Drawing.Point(192, 109);
            this.getResultsButton.Name = "getResultsButton";
            this.getResultsButton.Size = new System.Drawing.Size(75, 23);
            this.getResultsButton.TabIndex = 9;
            this.getResultsButton.Text = "Get Results";
            this.getResultsButton.UseVisualStyleBackColor = true;
            this.getResultsButton.Click += new System.EventHandler(this.getResults_buttonclick);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(845, 385);
            this.Controls.Add(this.getResultsButton);
            this.Controls.Add(this.setWallpaperButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.listingTypeCombo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.subChooserCombo);
            this.Controls.Add(this.searchTermInput);
            this.Controls.Add(this.resultsList);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Name = "MainWindow";
            this.Text = "Reddit Wallpaper Setter";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView resultsList;
        private System.Windows.Forms.TextBox searchTermInput;
        private System.Windows.Forms.ComboBox subChooserCombo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox listingTypeCombo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.Button setWallpaperButton;
        private System.Windows.Forms.Button getResultsButton;
        private System.Windows.Forms.ColumnHeader Titles;
    }
}

