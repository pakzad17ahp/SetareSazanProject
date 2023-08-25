using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SetareSazanProject
{
    public partial class TextBoxPro : TextBox
    {
        public bool IsIdAnbar { get; set; }

        public bool IsTextBoxCodeKala { get; set; }

        private Boolean _MouseWheelEnabled = true;
        public Boolean MouseWheelEnabled
        {
            get { return _MouseWheelEnabled; }
            set { _MouseWheelEnabled = value; }
        }

        public string ReplaceCurent(string str)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in str)
            {
                //ی
                if ((int)c == 1609 || (int)c == 1740)
                    sb.Append((char)1610);
                //ک
                else if ((int)c == 1706 || (int)c == 1705)
                    sb.Append((char)1603);
                //ه
                else if ((int)c == 1749 || (int)c == 1729)
                    sb.Append((char)1607);
                //ة
                else if ((int)c == 1731)
                    sb.Append((char)1577);
                //ۀ
                else if ((int)c == 1730)
                    sb.Append((char)1728);
                else
                    sb.Append(c);
            }
            return sb.ToString();
        }

        private Boolean _keydown = true;

        public Boolean KeyDownEnabled
        {
            get { return _keydown; }
            set { _keydown = value; }
        }

        private Boolean _persianOnly = false;

        public Boolean PersianOnly
        {
            get { return _persianOnly; }
            set { _persianOnly = value; }
        }


        private int _numint;

        public int NumInt
        {
            get
            {
                int.TryParse(this.Text, out _numint);
                return _numint;
            }
        }

        private Int64 _NumLong;

        public Int64 NumLong
        {
            get
            {
                Int64.TryParse(Text, out _NumLong);
                return _NumLong;
            }
        }

        private decimal _numdecimal;

        public Decimal NumDecimal
        {
            get
            {
                decimal.TryParse(this.Text, out _numdecimal);
                return _numdecimal;
            }
        }


        private Boolean _canEmpty = true;

        public Boolean CanEmpty
        {
            get { return _canEmpty; }
            set { _canEmpty = value; }
        }

        private Boolean _checkLength = false;

        public Boolean CheckLength
        {
            get { return _checkLength; }
            set { _checkLength = value; }
        }

        private int _lenght;

        public int Lenght
        {
            get { return _lenght; }
            set
            {
                _lenght = value;
                this.MaxLength = _lenght;
            }
        }


        private Boolean _isnumric = false;

        public Boolean IsNumric
        {
            get { return _isnumric; }
            set
            {
                if (value)
                {
                    this.RightToLeft = RightToLeft.Inherit;
                    IsDecimal = false;
                    IsString = false;
                }
                _isnumric = value;
            }
        }

        private Boolean _isdecimal = false;

        public Boolean IsDecimal
        {
            get { return _isdecimal; }
            set
            {
                if (value == true)
                {
                    this.RightToLeft = RightToLeft.No;
                    IsNumric = false;
                    IsString = false;
                }
                _isdecimal = value;
            }
        }

        private Boolean _isstring;

        public Boolean IsString
        {
            get { return _isstring; }
            set
            {
                if (value)
                {
                    this.RightToLeft = RightToLeft.Inherit;
                    IsDecimal = false;
                    IsNumric = false;
                }

                _isstring = value;
            }
        }

        private Boolean _isserial = false;


        public TextBoxPro()
        {
            InitializeComponent();
            //CreateContextMenu();
        }

        //public void CreateContextMenu()
        //{
        //    ContextMenuStrip menu = new ContextMenuStrip();
        //    menu.Opening += menu_Opening;

        //    ToolStripMenuItem undo = new ToolStripMenuItem("برگشت");
        //    undo.Name = "undo";
        //    //undo.ShortcutKeys = Keys.Control | Keys.Z;
        //    undo.Click += Menu_Click;
        //    undo.Image = SetareSazanProject.Componets.Properties.Resources.undoTextBox;
        //    menu.Items.Add(undo);

        //    ToolStripSeparator s1 = new ToolStripSeparator();
        //    menu.Items.Add(s1);

        //    ToolStripMenuItem cut = new ToolStripMenuItem("برداشتن");
        //    cut.Name = "cut";
        //    //cut.ShortcutKeys = Keys.Control | Keys.X;
        //    cut.Click += Menu_Click;
        //    cut.Image = SetareSazanProject.Componets.Properties.Resources.cut;
        //    menu.Items.Add(cut);

        //    ToolStripMenuItem copy = new ToolStripMenuItem("کپی کردن");
        //    copy.Name = "copy";
        //    //copy.ShortcutKeys = Keys.Control | Keys.C;
        //    copy.Click += Menu_Click;
        //    copy.Image = SetareSazanProject.Componets.Properties.Resources.copyTextBox;
        //    menu.Items.Add(copy);

        //    ToolStripMenuItem paste = new ToolStripMenuItem("چسباندن");
        //    paste.Name = "paste";
        //    //paste.ShortcutKeys = Keys.Control | Keys.V;
        //    paste.Click += Menu_Click;
        //    paste.Image = SetareSazanProject.Componets.Properties.Resources.paste;
        //    menu.Items.Add(paste);

        //    ToolStripMenuItem delete = new ToolStripMenuItem("حذف");
        //    delete.Name = "delete";
        //    //delete.ShortcutKeys = Keys.Delete;
        //    delete.Click += Menu_Click;
        //    delete.Image = SetareSazanProject.Componets.Properties.Resources.gnome_edit_delete;
        //    menu.Items.Add(delete);

        //    ToolStripSeparator s2 = new ToolStripSeparator();
        //    menu.Items.Add(s2);

        //    ToolStripMenuItem selectAll = new ToolStripMenuItem("انتخاب همه");
        //    selectAll.Name = "selectAll";
        //    selectAll.Click += Menu_Click;
        //    //selectAll.ShortcutKeys = Keys.Control | Keys.A;
        //    selectAll.Image = SetareSazanProject.Componets.Properties.Resources.edit_select_all;
        //    menu.Items.Add(selectAll);

        //    this.ContextMenuStrip = menu;
        //}

        private void menu_Opening(object sender, CancelEventArgs e)
        {
            try
            {
                var menu = sender as ContextMenuStrip;
                if (menu == null) return;
                menu.Items["undo"].Enabled = CanUndo;
                if (SelectedText.Length == 0)
                {
                    menu.Items["cut"].Enabled = false;
                    menu.Items["copy"].Enabled = false;
                    menu.Items["delete"].Enabled = false;
                }
                else
                {
                    menu.Items["cut"].Enabled = true;
                    menu.Items["copy"].Enabled = true;
                    menu.Items["delete"].Enabled = true;
                }
                menu.Items["paste"].Enabled = Clipboard.ContainsText();
                menu.Items["selectAll"].Enabled = Text.Length != 0;
            }
            catch
            { }
        }

        private void Menu_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem menu = (ToolStripMenuItem)sender;
            if (menu.Name == "undo")
                this.Undo();
            else if (menu.Name == "cut")
                this.Cut();
            else if (menu.Name == "copy")
                this.Copy();
            else if (menu.Name == "paste")
                this.Paste();
            else if (menu.Name == "selectAll")
                this.SelectAll();
            else if (menu.Name == "delete")
            {
                int SelectionIndex = this.SelectionStart;
                int SelectionCount = this.SelectionLength;
                this.Text = this.Text.Remove(SelectionIndex, SelectionCount);
                this.SelectionStart = SelectionIndex;
            }
        }

        private void TextBoxPro_Load(object sender, EventArgs e)
        {
        }

        private void TextBoxPro_Enter(object sender, EventArgs e)
        {
            this.BackColor = Color.LightYellow;
            //this.ForeColor = Color.White;
            this.SelectAll();
        }

        private void TextBoxPro_Leave(object sender, EventArgs e)
        {
            //this.ForeColor = Color.Black;
            this.BackColor = Color.White;
            //if (_checkLength)
            //{
            //    if (this.Text.Length != _lenght && this.NumInt > 0)
            //    {
            //        MessageBoxFarsi.Show("باید " + _lenght + "رقمی شود", "", MessageBoxFarsiButtons.OK,
            //            MessageBoxFarsiIcon.Warning);
            //        this.Select();
            //    }
            //}
            //if (_canEmpty == false)
            //{
            //    if (this.Text.Length == 0)
            //    {
            //        MessageBoxFarsi.Show("نمی تواند خالی رها شود", "", MessageBoxFarsiButtons.OK,
            //            MessageBoxFarsiIcon.Warning);
            //        this.Select();
            //    }
            //}
        }

        public static bool IsPersianLetter(char letter)
        {
            string persianLetter = "ءآأؤإئابةتثجحخدذرزسشصضطظعغفقكلمنهوىيٲٳٴٵٶپچژکڪگھۀہۂۃیە";
            return (persianLetter.IndexOf(letter) > -1);
        }

        private void TextBoxPro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ("'" == e.KeyChar.ToString())
                e.Handled = true;

            if (PersianOnly)
            {
                if (IsPersianLetter(e.KeyChar) == false)
                {
                    e.Handled = true;
                    e.KeyChar = '\0';
                }
            }
            if (_isnumric)
            {
                if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != 8)
                {
                    e.Handled = true;
                    e.KeyChar = '\0';
                }
            }
            else if (_isdecimal)
            {
                if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != 8 && e.KeyChar != '.' && e.KeyChar != '-')
                {
                    e.Handled = true;
                    e.KeyChar = '\0';
                }
            }
            else
            {
                char c = e.KeyChar;
                if ((int)c == 1609 || (int)c == 1740)
                    e.KeyChar = ((char)1610);
                //ک
                else if ((int)c == 1706 || (int)c == 1705)
                    e.KeyChar = ((char)1603);
                //ه
                else if ((int)c == 1749 || (int)c == 1729)
                    e.KeyChar = ((char)1607);
                //ة
                else if ((int)c == 1731)
                    e.KeyChar = ((char)1577);
                //ۀ
                else if ((int)c == 1730)
                    e.KeyChar = ((char)1728);

                //switch (e.KeyChar)
                //{
                //    case 'ی':
                //        e.KeyChar = 'ي';
                //        break;
                //    case 'ک':
                //        e.KeyChar = 'ك';
                //        break;

                //    default:
                //        break;
                //}


                //e.KeyChar = text.Replace("", ""); // ک
                //text = text.Replace(, ""); // ی
                //text = text.Replace("", "); // ی
                //text = text.Replace(", "\u0647\u0654"); // هٔ
            }
        }

        public bool PressEnter { get; set; } = false;
        private void TextBoxPro_KeyDown(object sender, KeyEventArgs e)
        {
            
            
            
            PressEnter = false;
            if (_keydown)
            {
                if (e.KeyData == Keys.Enter)
                {
                    PressEnter = true;
                    if (this.Parent != null)
                    {
                        if (this.Parent.Parent != null)
                        {
                            if (this.Parent.Parent.Parent != null)
                            {
                                if (this.Parent.Parent.Parent.Parent != null)
                                {
                                    if (this.Parent.Parent.Parent.Parent.Parent != null)
                                        this.Parent.Parent.Parent.Parent.Parent.SelectNextControl(this as Control, true, true, true, true);
                                    else
                                        this.Parent.Parent.Parent.Parent.SelectNextControl(this as Control, true, true, true, true);
                                }
                                else
                                    this.Parent.Parent.Parent.SelectNextControl(this as Control, true, true, true, true);
                            }
                            else
                                this.Parent.Parent.SelectNextControl(this as Control, true, true, true, true);
                        }
                        else
                            this.Parent.SelectNextControl(this as Control, true, true, true, true);
                    }
                    else
                        this.SelectNextControl(this as Control, true, true, true, true);
                }
                else if (e.KeyData == Keys.Up)
                    if (this.Parent.Parent != null)
                    {
                        if (this.Parent.Parent.Parent != null)
                            this.Parent.Parent.Parent.SelectNextControl(this as Control, false, true, true, true);
                        else
                            this.Parent.Parent.SelectNextControl(this as Control, false, true, true, true);
                    }
                    else
                        this.Parent.SelectNextControl(this as Control, false, true, true, true);
                // قطع صدای Beep
                if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Escape))
                    e.Handled = e.SuppressKeyPress = true;
            }
        }

        private void TextBoxPro_EnabledChanged(object sender, EventArgs e)
        {
            if (this.Enabled == false)
            {
                this.BackColor = Color.FromKnownColor(KnownColor.Control);
            } // this.Text = ""; }
            else this.BackColor = Color.White;
        }

        public static string FixPersianString(string text)
        {
            if (text == null)
                return null;

            //text = text.Replace("\u0660", "\u06F0"); // ۰
            //text = text.Replace("\u0661", "\u06F1"); // ۱
            //text = text.Replace("\u0662", "\u06F2"); // ۲
            //text = text.Replace("\u0663", "\u06F3"); // ۳
            //text = text.Replace("\u0664", "\u06F4"); // ۴
            //text = text.Replace("\u0665", "\u06F5"); // ۵
            //text = text.Replace("\u0666", "\u06F6"); // ۶
            //text = text.Replace("\u0667", "\u06F7"); // ۷
            //text = text.Replace("\u0668", "\u06F8"); // ۸
            //text = text.Replace("\u0669", "\u06F9"); // ۹
            text = text.Replace("\u0643", "\u06A9"); // ک
            text = text.Replace("\u0649", "\u06CC"); // ی
            text = text.Replace("\u064A", "\u06CC"); // ی
            text = text.Replace("\u06C0", "\u0647\u0654"); // هٔ

            return text;
        }

        private void TextBoxPro_TextChanged(object sender, EventArgs e)
        {
        }

        private void TextBoxPro_MouseWheel(object sender, MouseEventArgs e)
        {
            //try
            // {
            //     if (Text.IsNumeric())
            //     {
            //         if (Text.ToInt() >= 0 && MouseWheelEnabled && this.ReadOnly==false)
            //         {
            //             string text = Text.ToInt().ToString();
            //             string first = text[0].ToString();
            //             string other = text.Substring(1);
            //             if (e.Delta > 0)
            //                 Text = first.ToInt() + 1 + other;
            //             else if (Text.ToInt() > 0)
            //                 Text = first != "1"
            //                     ? first.ToInt() - 1 + other
            //                     : (text.Length > 1 ? "9" + text.Substring(2) : "0");
            //         }
            //     }
            // }
            // catch
            // {
            // }
        }
        public void MakeZero()
        {
            Text = "0";
        }

        private Form _formparent;
        private void TextBoxPro_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (_formparent == null)
                    SetForm();
                if (_formparent != null)
                {
                    _formparent.Activate();
                    _formparent.BringToFront();
                }
            }
        }

        private void SetForm()
        {
            Control cont = this;
            while (cont != null)
            {
                if (cont.Parent == null)
                {
                    _formparent = (cont as Form);
                    return;
                }
                cont = cont.Parent;
            }
        }
    }
}