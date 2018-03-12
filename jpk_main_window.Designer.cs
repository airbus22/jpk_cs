namespace jpkapp
{
    partial class Jpk_main_window
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Jpk_main_window));
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.DTP_poczatkowa = new System.Windows.Forms.DateTimePicker();
            this.DTP_koncowa = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.pilikToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zakończToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.komunikaty_lbl = new System.Windows.Forms.Label();
            this.poczatkowa_lbl = new System.Windows.Forms.Label();
            this.koncowa_lbl = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button1.Location = new System.Drawing.Point(131, 196);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(267, 89);
            this.button1.TabIndex = 0;
            this.button1.Text = "Generuj plik JPK MAG";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(86, 158);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(359, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Przedział dat należy podawać w ująciu pełnych, kalendarzowych miesięcy";
            // 
            // DTP_poczatkowa
            // 
            this.DTP_poczatkowa.Location = new System.Drawing.Point(14, 36);
            this.DTP_poczatkowa.Name = "DTP_poczatkowa";
            this.DTP_poczatkowa.Size = new System.Drawing.Size(200, 20);
            this.DTP_poczatkowa.TabIndex = 3;
            // 
            // DTP_koncowa
            // 
            this.DTP_koncowa.Location = new System.Drawing.Point(14, 34);
            this.DTP_koncowa.Name = "DTP_koncowa";
            this.DTP_koncowa.Size = new System.Drawing.Size(200, 20);
            this.DTP_koncowa.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.koncowa_lbl);
            this.groupBox1.Controls.Add(this.DTP_koncowa);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.groupBox1.Location = new System.Drawing.Point(277, 55);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(228, 100);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Data końcowa";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.poczatkowa_lbl);
            this.groupBox2.Controls.Add(this.DTP_poczatkowa);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.groupBox2.Location = new System.Drawing.Point(23, 55);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(228, 100);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Data początkowa";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pilikToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(531, 24);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // pilikToolStripMenuItem
            // 
            this.pilikToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zakończToolStripMenuItem});
            this.pilikToolStripMenuItem.Name = "pilikToolStripMenuItem";
            this.pilikToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.pilikToolStripMenuItem.Text = "Pilik";
            // 
            // zakończToolStripMenuItem
            // 
            this.zakończToolStripMenuItem.Name = "zakończToolStripMenuItem";
            this.zakończToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.zakończToolStripMenuItem.Text = "Zakończ";
            this.zakończToolStripMenuItem.Click += new System.EventHandler(this.ZakończToolStripMenuItem_Click);
            // 
            // komunikaty_lbl
            // 
            this.komunikaty_lbl.AutoSize = true;
            this.komunikaty_lbl.Location = new System.Drawing.Point(6, 314);
            this.komunikaty_lbl.Name = "komunikaty_lbl";
            this.komunikaty_lbl.Size = new System.Drawing.Size(0, 13);
            this.komunikaty_lbl.TabIndex = 10;
            // 
            // poczatkowa_lbl
            // 
            this.poczatkowa_lbl.AutoSize = true;
            this.poczatkowa_lbl.Location = new System.Drawing.Point(11, 70);
            this.poczatkowa_lbl.Name = "poczatkowa_lbl";
            this.poczatkowa_lbl.Size = new System.Drawing.Size(41, 13);
            this.poczatkowa_lbl.TabIndex = 4;
            this.poczatkowa_lbl.Text = "label2";
            // 
            // koncowa_lbl
            // 
            this.koncowa_lbl.AutoSize = true;
            this.koncowa_lbl.Location = new System.Drawing.Point(11, 70);
            this.koncowa_lbl.Name = "koncowa_lbl";
            this.koncowa_lbl.Size = new System.Drawing.Size(41, 13);
            this.koncowa_lbl.TabIndex = 5;
            this.koncowa_lbl.Text = "label3";
            // 
            // Jpk_main_window
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(531, 331);
            this.Controls.Add(this.komunikaty_lbl);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Jpk_main_window";
            this.Text = "JPK Magazyn";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker DTP_poczatkowa;
        private System.Windows.Forms.DateTimePicker DTP_koncowa;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem pilikToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zakończToolStripMenuItem;
        private System.Windows.Forms.Label komunikaty_lbl;
        private System.Windows.Forms.Label koncowa_lbl;
        private System.Windows.Forms.Label poczatkowa_lbl;
    }
}

