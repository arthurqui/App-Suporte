            
namespace botmap
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btn_iniciar = new System.Windows.Forms.Button();
            this.txt_dep = new System.Windows.Forms.TextBox();
            this.lbl_publicoAlvo = new System.Windows.Forms.Label();
            this.txt_nome = new System.Windows.Forms.TextBox();
            this.lbl_regiao = new System.Windows.Forms.Label();
            this.lbl_obs = new System.Windows.Forms.Label();
            this.txt_oco = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_iniciar
            // 
            this.btn_iniciar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(111)))), ((int)(((byte)(154)))));
            this.btn_iniciar.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btn_iniciar.ForeColor = System.Drawing.SystemColors.Control;
            this.btn_iniciar.Location = new System.Drawing.Point(454, 319);
            this.btn_iniciar.Name = "btn_iniciar";
            this.btn_iniciar.Size = new System.Drawing.Size(107, 42);
            this.btn_iniciar.TabIndex = 0;
            this.btn_iniciar.Text = "Enviar";
            this.btn_iniciar.UseVisualStyleBackColor = false;
            this.btn_iniciar.Click += new System.EventHandler(this.btn_iniciar_Click);
            // 
            // txt_dep
            // 
            this.txt_dep.Location = new System.Drawing.Point(137, 176);
            this.txt_dep.Name = "txt_dep";
            this.txt_dep.PlaceholderText = "Ex: Marketing";
            this.txt_dep.Size = new System.Drawing.Size(152, 27);
            this.txt_dep.TabIndex = 1;
            this.txt_dep.TextChanged += new System.EventHandler(this.txt_publicoAlvo_TextChanged);
            // 
            // lbl_publicoAlvo
            // 
            this.lbl_publicoAlvo.AutoSize = true;
            this.lbl_publicoAlvo.BackColor = System.Drawing.Color.Transparent;
            this.lbl_publicoAlvo.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbl_publicoAlvo.Location = new System.Drawing.Point(11, 177);
            this.lbl_publicoAlvo.Name = "lbl_publicoAlvo";
            this.lbl_publicoAlvo.Size = new System.Drawing.Size(120, 23);
            this.lbl_publicoAlvo.TabIndex = 2;
            this.lbl_publicoAlvo.Text = "Departamento:";
            this.lbl_publicoAlvo.Click += new System.EventHandler(this.label1_Click);
            // 
            // txt_nome
            // 
            this.txt_nome.Location = new System.Drawing.Point(137, 226);
            this.txt_nome.Name = "txt_nome";
            this.txt_nome.PlaceholderText = "Ex: Fulano da Silva";
            this.txt_nome.Size = new System.Drawing.Size(424, 27);
            this.txt_nome.TabIndex = 3;
            // 
            // lbl_regiao
            // 
            this.lbl_regiao.AutoSize = true;
            this.lbl_regiao.BackColor = System.Drawing.Color.Transparent;
            this.lbl_regiao.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbl_regiao.Location = new System.Drawing.Point(73, 229);
            this.lbl_regiao.Name = "lbl_regiao";
            this.lbl_regiao.Size = new System.Drawing.Size(57, 23);
            this.lbl_regiao.TabIndex = 4;
            this.lbl_regiao.Text = "Nome:";
            this.lbl_regiao.Click += new System.EventHandler(this.lbl_regiao_Click);
            // 
            // lbl_obs
            // 
            this.lbl_obs.AutoSize = true;
            this.lbl_obs.BackColor = System.Drawing.Color.Transparent;
            this.lbl_obs.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbl_obs.Location = new System.Drawing.Point(37, 277);
            this.lbl_obs.Name = "lbl_obs";
            this.lbl_obs.Size = new System.Drawing.Size(94, 23);
            this.lbl_obs.TabIndex = 5;
            this.lbl_obs.Text = "Ocorrência:";
            this.lbl_obs.Click += new System.EventHandler(this.lbl_obs_Click);
            // 
            // txt_oco
            // 
            this.txt_oco.Location = new System.Drawing.Point(137, 277);
            this.txt_oco.Name = "txt_oco";
            this.txt_oco.PlaceholderText = "Ex: Minha internet não conecta";
            this.txt_oco.Size = new System.Drawing.Size(424, 27);
            this.txt_oco.TabIndex = 6;
            this.txt_oco.TextChanged += new System.EventHandler(this.txt_obs_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(137, 330);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(300, 23);
            this.label2.TabIndex = 7;
            this.label2.Text = "Envie seu chamado de suporte para o TI";
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(587, 373);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_oco);
            this.Controls.Add(this.lbl_obs);
            this.Controls.Add(this.lbl_regiao);
            this.Controls.Add(this.txt_nome);
            this.Controls.Add(this.lbl_publicoAlvo);
            this.Controls.Add(this.txt_dep);
            this.Controls.Add(this.btn_iniciar);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Abrir Suporte de TI";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_iniciar;
        private System.Windows.Forms.TextBox txt_dep;
        private System.Windows.Forms.Label lbl_publicoAlvo;
        private System.Windows.Forms.TextBox txt_nome;
        private System.Windows.Forms.Label lbl_regiao;
        private System.Windows.Forms.Label lbl_obs;
        private System.Windows.Forms.TextBox txt_oco;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

