namespace CryptoAgregator.UI
{
    partial class MainForm
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
            symbolsList = new TabControl();
            tabPage1 = new TabPage();
            binanceSymbolPriceTextBox = new TextBox();
            binanceSymbolsList = new ListBox();
            tabPage2 = new TabPage();
            bybitSymbolPriceTextBox = new TextBox();
            bybitSymbolsList = new ListBox();
            tabPage3 = new TabPage();
            kucoinSymbolPriceTextBox = new TextBox();
            kucoinSymbolsList = new ListBox();
            tabPage4 = new TabPage();
            mexcSymbolPriceTextBox = new TextBox();
            mexcSymbolsList = new ListBox();
            symbolsList.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            tabPage3.SuspendLayout();
            tabPage4.SuspendLayout();
            SuspendLayout();
            // 
            // symbolsList
            // 
            symbolsList.Controls.Add(tabPage1);
            symbolsList.Controls.Add(tabPage2);
            symbolsList.Controls.Add(tabPage3);
            symbolsList.Controls.Add(tabPage4);
            symbolsList.Location = new Point(12, 12);
            symbolsList.Name = "symbolsList";
            symbolsList.SelectedIndex = 0;
            symbolsList.Size = new Size(411, 412);
            symbolsList.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(binanceSymbolPriceTextBox);
            tabPage1.Controls.Add(binanceSymbolsList);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(403, 384);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Binance";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // binanceSymbolPriceTextBox
            // 
            binanceSymbolPriceTextBox.Enabled = false;
            binanceSymbolPriceTextBox.Location = new Point(199, 3);
            binanceSymbolPriceTextBox.Name = "binanceSymbolPriceTextBox";
            binanceSymbolPriceTextBox.Size = new Size(198, 23);
            binanceSymbolPriceTextBox.TabIndex = 1;
            // 
            // binanceSymbolsList
            // 
            binanceSymbolsList.Enabled = false;
            binanceSymbolsList.FormattingEnabled = true;
            binanceSymbolsList.ItemHeight = 15;
            binanceSymbolsList.Location = new Point(3, 3);
            binanceSymbolsList.Name = "binanceSymbolsList";
            binanceSymbolsList.Size = new Size(190, 379);
            binanceSymbolsList.TabIndex = 0;
            binanceSymbolsList.SelectedIndexChanged += binanceSymbolsList_SelectedIndexChanged;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(bybitSymbolPriceTextBox);
            tabPage2.Controls.Add(bybitSymbolsList);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(403, 384);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Bybit";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // bybitSymbolPriceTextBox
            // 
            bybitSymbolPriceTextBox.Enabled = false;
            bybitSymbolPriceTextBox.Location = new Point(199, 3);
            bybitSymbolPriceTextBox.Name = "bybitSymbolPriceTextBox";
            bybitSymbolPriceTextBox.Size = new Size(198, 23);
            bybitSymbolPriceTextBox.TabIndex = 1;
            // 
            // bybitSymbolsList
            // 
            bybitSymbolsList.Enabled = false;
            bybitSymbolsList.FormattingEnabled = true;
            bybitSymbolsList.ItemHeight = 15;
            bybitSymbolsList.Location = new Point(3, 3);
            bybitSymbolsList.Name = "bybitSymbolsList";
            bybitSymbolsList.Size = new Size(190, 379);
            bybitSymbolsList.TabIndex = 0;
            bybitSymbolsList.SelectedIndexChanged += bybitSymbolsList_SelectedIndexChanged;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(kucoinSymbolPriceTextBox);
            tabPage3.Controls.Add(kucoinSymbolsList);
            tabPage3.Location = new Point(4, 24);
            tabPage3.Name = "tabPage3";
            tabPage3.Size = new Size(403, 384);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Kucoin";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // kucoinSymbolPriceTextBox
            // 
            kucoinSymbolPriceTextBox.Enabled = false;
            kucoinSymbolPriceTextBox.Location = new Point(199, 3);
            kucoinSymbolPriceTextBox.Name = "kucoinSymbolPriceTextBox";
            kucoinSymbolPriceTextBox.Size = new Size(201, 23);
            kucoinSymbolPriceTextBox.TabIndex = 1;
            // 
            // kucoinSymbolsList
            // 
            kucoinSymbolsList.Enabled = false;
            kucoinSymbolsList.FormattingEnabled = true;
            kucoinSymbolsList.ItemHeight = 15;
            kucoinSymbolsList.Location = new Point(3, 3);
            kucoinSymbolsList.Name = "kucoinSymbolsList";
            kucoinSymbolsList.Size = new Size(190, 379);
            kucoinSymbolsList.TabIndex = 0;
            kucoinSymbolsList.SelectedIndexChanged += kucoinSymbolsList_SelectedIndexChanged;
            // 
            // tabPage4
            // 
            tabPage4.Controls.Add(mexcSymbolPriceTextBox);
            tabPage4.Controls.Add(mexcSymbolsList);
            tabPage4.Location = new Point(4, 24);
            tabPage4.Name = "tabPage4";
            tabPage4.Size = new Size(403, 384);
            tabPage4.TabIndex = 3;
            tabPage4.Text = "Mexc";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // mexcSymbolPriceTextBox
            // 
            mexcSymbolPriceTextBox.Enabled = false;
            mexcSymbolPriceTextBox.Location = new Point(199, 3);
            mexcSymbolPriceTextBox.Name = "mexcSymbolPriceTextBox";
            mexcSymbolPriceTextBox.Size = new Size(201, 23);
            mexcSymbolPriceTextBox.TabIndex = 1;
            // 
            // mexcSymbolsList
            // 
            mexcSymbolsList.Enabled = false;
            mexcSymbolsList.FormattingEnabled = true;
            mexcSymbolsList.ItemHeight = 15;
            mexcSymbolsList.Location = new Point(3, 3);
            mexcSymbolsList.Name = "mexcSymbolsList";
            mexcSymbolsList.Size = new Size(190, 379);
            mexcSymbolsList.TabIndex = 0;
            mexcSymbolsList.SelectedIndexChanged += mexcSymbolsList_SelectedIndexChanged;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(436, 437);
            Controls.Add(symbolsList);
            Name = "MainForm";
            Text = "MainForm";
            symbolsList.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            tabPage3.ResumeLayout(false);
            tabPage3.PerformLayout();
            tabPage4.ResumeLayout(false);
            tabPage4.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl symbolsList;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private ListBox binanceSymbolsList;
        private ListBox bybitSymbolsList;
        private TabPage tabPage3;
        private ListBox kucoinSymbolsList;
        private TabPage tabPage4;
        private ListBox mexcSymbolsList;
        private TextBox binanceSymbolPriceTextBox;
        private TextBox bybitSymbolPriceTextBox;
        private TextBox kucoinSymbolPriceTextBox;
        private TextBox mexcSymbolPriceTextBox;
    }
}