using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace fifaSSS
{
    public partial class Form1 : Form
    {
        static int boxsize = 49;

        //뽑기횟수 세기
        static int pick_count = 0;
        //판갈기 세기
        static int change_count = 0;

        static int mySSS = 1;
        static int mySS = 2;
        static int myS = 6;
        static int myA = 10;
        static int myB = 18;
        static int myC = 12;
        private void resetcount()
        {
            mySSS = 1;
            mySS = 2;
            myS = 6;
            myA = 10;
            myB = 18;
            myC = 12;
            C_.Text = "C : " + myC.ToString() + "개";
            B_.Text = "B : " + myB.ToString() + "개";
            A_.Text = "A : " + myA.ToString() + "개";
            S_.Text = "S : " + myS.ToString() + "개";
            SS_.Text = "SS : " + mySS.ToString() + "개";
            SSS_.Text = "SSS : " + mySSS.ToString() + "개";
        }


        Button[] btn = new Button[boxsize]; //initialized the buttons
        Label[] labels = new Label[boxsize];
        public Form1()
        {
            InitializeComponent();

            for (int t = 0; t < boxsize; t++) //this loop makes all the buttons assigned to a button
            {
                btn[t] = new Button();
                labels[t] = new Label();
            }

            changeFunc(); //first calculation
            btn[0].Click += new System.EventHandler(btn0Click); //here i assign the functions to buttons
            btn[1].Click += new System.EventHandler(btn1Click);
            btn[2].Click += new System.EventHandler(btn2Click);
            btn[3].Click += new System.EventHandler(btn3Click);
            btn[4].Click += new System.EventHandler(btn4Click);
            btn[5].Click += new System.EventHandler(btn5Click);
            btn[6].Click += new System.EventHandler(btn6Click);
            btn[7].Click += new System.EventHandler(btn7Click);
            btn[8].Click += new System.EventHandler(btn8Click);
            btn[9].Click += new System.EventHandler(btn9Click);
            btn[10].Click += new System.EventHandler(btn10Click);
            btn[11].Click += new System.EventHandler(btn11Click);
            btn[12].Click += new System.EventHandler(btn12Click);
            btn[13].Click += new System.EventHandler(btn13Click);
            btn[14].Click += new System.EventHandler(btn14Click);
            btn[15].Click += new System.EventHandler(btn15Click);
            btn[16].Click += new System.EventHandler(btn16Click);
            btn[17].Click += new System.EventHandler(btn17Click);
            btn[18].Click += new System.EventHandler(btn18Click);
            btn[19].Click += new System.EventHandler(btn19Click);
            btn[20].Click += new System.EventHandler(btn20Click);
            btn[21].Click += new System.EventHandler(btn21Click);
            btn[22].Click += new System.EventHandler(btn22Click);
            btn[23].Click += new System.EventHandler(btn23Click);
            btn[24].Click += new System.EventHandler(btn24Click);
            btn[25].Click += new System.EventHandler(btn25Click);
            btn[26].Click += new System.EventHandler(btn26Click);
            btn[27].Click += new System.EventHandler(btn27Click);
            btn[28].Click += new System.EventHandler(btn28Click);
            btn[29].Click += new System.EventHandler(btn29Click);
            btn[30].Click += new System.EventHandler(btn30Click);
            btn[31].Click += new System.EventHandler(btn31Click);
            btn[32].Click += new System.EventHandler(btn32Click);
            btn[33].Click += new System.EventHandler(btn33Click);
            btn[34].Click += new System.EventHandler(btn34Click);
            btn[35].Click += new System.EventHandler(btn35Click);
            btn[36].Click += new System.EventHandler(btn36Click);
            btn[37].Click += new System.EventHandler(btn37Click);
            btn[38].Click += new System.EventHandler(btn38Click);
            btn[39].Click += new System.EventHandler(btn39Click);
            btn[40].Click += new System.EventHandler(btn40Click);
            btn[41].Click += new System.EventHandler(btn41Click);
            btn[42].Click += new System.EventHandler(btn42Click);
            btn[43].Click += new System.EventHandler(btn43Click);
            btn[44].Click += new System.EventHandler(btn44Click);
            btn[45].Click += new System.EventHandler(btn45Click);
            btn[46].Click += new System.EventHandler(btn46Click);
            btn[47].Click += new System.EventHandler(btn47Click);
            btn[48].Click += new System.EventHandler(btn48Click);

            //SSS판 만들기
            makeSSS();

            //남은 갯수 리셋
            resetcount();
        }
        private void changeFunc()
        {
            for (int i = 0; i < boxsize; i++) //here i assign some necessary values to buttons and read the count numbers from memory
            {
                btn[i].Name = "btn_" + i; //the names are changed!
                btn[i].TabIndex = i;
                btn[i].Text = (i+1).ToString();
                btn[i].Size = new Size(50, 50);
                btn[i].Visible = true;
                btn[i].Parent = this;
                btn[i].FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                btn[i].Font = new Font(FontFamily.GenericSansSerif, 8.0F, FontStyle.Bold);
                btn[i].BackColor = Color.FromArgb(255, 255, 255);
                btn[i].Location = new Point(50 + (50 * (i % 7)), (i / 7) * 50 + 50);

                labels[i].Name = "label_" + i;
                labels[i].TabIndex = 0;
                labels[i].Text = "-";
                labels[i].Size = new Size(50, 50);
                labels[i].Visible = true;
                labels[i].Parent = this;
                labels[i].FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                labels[i].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                labels[i].Font = new Font(FontFamily.GenericSansSerif, 12.0F, FontStyle.Bold);
                labels[i].Location = new Point(50 + (50 * (i % 7)), (i / 7) * 50 + 50);

            }
        }
        static int hint_count = 1;
        private void hidebtn(int num)
        {
            btn[num].Visible = false;
            pick_count++;
            label3.Text = pick_count.ToString() + "회";

            if(labels[num].Text == "C")
            {
                if(num == 0)
                {
                    if(btn[num + 1].Text != (num + 2).ToString() + "\nA이상")
                    {
                        btn[num + 1].BackColor = Color.FromArgb(255, 136, 55);
                        btn[num + 1].Text = (num + 2).ToString() + "\nB이상";
                    }
                }
                else if(num == 48)
                {
                    //btn[num - 1].BackColor = Color.FromArgb(255, 136, 55);
                    //btn[num - 1].Text = (num).ToString() + "\nB이상";
                    if (btn[num - 1].Text != (num).ToString() + "\nA이상")
                    {
                        btn[num - 1].BackColor = Color.FromArgb(255, 136, 55);
                        btn[num - 1].Text = (num).ToString() + "\nB이상";
                    }
                }
                else
                {
                    //btn[num - 1].BackColor = Color.FromArgb(255, 136, 55);
                    //btn[num + 1].BackColor = Color.FromArgb(255, 136, 55);
                    if (btn[num - 1].Text != (num).ToString() + "\nA이상")
                    {
                        btn[num - 1].BackColor = Color.FromArgb(255, 136, 55);
                        btn[num - 1].Text = (num).ToString() + "\nB이상";
                    }
                    if (btn[num + 1].Text != (num+2).ToString() + "\nA이상")
                    {
                        btn[num + 1].BackColor = Color.FromArgb(255, 136, 55);
                        btn[num + 1].Text = (num+2).ToString() + "\nB이상";
                    }
                    //btn[num - 1].Text = (num).ToString() + "\nB이상";
                    //btn[num + 1].Text = (num+2).ToString() + "\nB이상";
                }
            }

            //남은갯수 빼기
            if (labels[num].Text == "C")
            {
                myC = myC - 1;
                C_.Text = "C : " + myC.ToString() + "개";
            }
            else if(labels[num].Text == "B")
            {
                myB = myB - 1;
                B_.Text = "B : " + myB.ToString() + "개";
            }
            else if (labels[num].Text == "A")
            {
                myA = myA - 1;
                A_.Text = "A : " + myA.ToString() + "개";
            }
            else if (labels[num].Text == "S")
            {
                myS = myS - 1;
                S_.Text = "S : " + myS.ToString() + "개";
            }
            else if (labels[num].Text == "SS")
            {
                mySS = mySS - 1;
                SS_.Text = "SS : " + mySS.ToString() + "개";
            }
            else
            {
                mySSS = mySSS - 1;
                SSS_.Text = "SSS : " + mySSS.ToString() + "개";
            }

            if (hint_count == 0)
            {
                hint01.Text = "X";
                hint02.Text = "X";
                hint03.Text = "X";
                hint_count++;
            }
            else if (hint_count == 1)
            {
                hint01.Text = "O";
                hint02.Text = "X";
                hint03.Text = "X";
                hint_count++;
            }
            else if(hint_count == 2)
            {
                hint01.Text = "O";
                hint02.Text = "O";
                hint03.Text = "X";
                hint_count++;
            }
            else if(hint_count == 3)
            {
                hint01.Text = "O";
                hint02.Text = "O";
                hint03.Text = "O";
                hint_count = 0;

                Random rd = new Random();
                try
                {
                    int tmp = rd.Next(0, A_UP.Count);
                    int tmp2 = Int32.Parse(A_UP[tmp].ToString());
                    btn[tmp2].BackColor = Color.FromArgb(0, 204, 97);
                    btn[tmp2].Text = (tmp2 + 1).ToString() + "\nA이상";
                }
                catch
                {

                }

            }

            
            if (labels[num].Text == "A" || labels[num].Text == "S" || labels[num].Text == "SS" || labels[num].Text == "SSS")
            {
                A_UP.Remove(num);
            }
        }

        private void btn0Click(Object sender, EventArgs e)
        {
            hidebtn(0);
        }
        private void btn1Click(Object sender, EventArgs e)
        {
            hidebtn(1);
        }
        private void btn2Click(Object sender, EventArgs e)
        {
            hidebtn(2);
        }
        private void btn3Click(Object sender, EventArgs e)
        {
            hidebtn(3);
        }
        private void btn4Click(Object sender, EventArgs e)
        {
            hidebtn(4);
        }
        private void btn5Click(Object sender, EventArgs e)
        {
            hidebtn(5);
        }
        private void btn6Click(Object sender, EventArgs e)
        {
            hidebtn(6);
        }
        private void btn7Click(Object sender, EventArgs e)
        {
            hidebtn(7);
        }
        private void btn8Click(Object sender, EventArgs e)
        {
            hidebtn(8);
        }
        private void btn9Click(Object sender, EventArgs e)
        {
            hidebtn(9);
        }
        private void btn10Click(Object sender, EventArgs e)
        {
            hidebtn(10);
        }
        private void btn11Click(Object sender, EventArgs e)
        {
            hidebtn(11);
        }
        private void btn12Click(Object sender, EventArgs e)
        {
            hidebtn(12);
        }
        private void btn13Click(Object sender, EventArgs e)
        {
            hidebtn(13);
        }
        private void btn14Click(Object sender, EventArgs e)
        {
            hidebtn(14);
        }
        private void btn15Click(Object sender, EventArgs e)
        {
            hidebtn(15);
        }
        private void btn16Click(Object sender, EventArgs e)
        {
            hidebtn(16);
        }
        private void btn17Click(Object sender, EventArgs e)
        {
            hidebtn(17);
        }
        private void btn18Click(Object sender, EventArgs e)
        {
            hidebtn(18);
        }
        private void btn19Click(Object sender, EventArgs e)
        {
            hidebtn(19);
        }
        private void btn20Click(Object sender, EventArgs e)
        {
            hidebtn(20);
        }
        private void btn21Click(Object sender, EventArgs e)
        {
            hidebtn(21);
        }
        private void btn22Click(Object sender, EventArgs e)
        {
            hidebtn(22);
        }
        private void btn23Click(Object sender, EventArgs e)
        {
            hidebtn(23);
        }
        private void btn24Click(Object sender, EventArgs e)
        {
            hidebtn(24);
        }
        private void btn25Click(Object sender, EventArgs e)
        {
            hidebtn(25);
        }
        private void btn26Click(Object sender, EventArgs e)
        {
            hidebtn(26);
        }
        private void btn27Click(Object sender, EventArgs e)
        {
            hidebtn(27);
        }
        private void btn28Click(Object sender, EventArgs e)
        {
            hidebtn(28);
        }
        private void btn29Click(Object sender, EventArgs e)
        {
            hidebtn(29);
        }
        private void btn30Click(Object sender, EventArgs e)
        {
            hidebtn(30);
        }
        private void btn31Click(Object sender, EventArgs e)
        {
            hidebtn(31);
        }
        private void btn32Click(Object sender, EventArgs e)
        {
            hidebtn(32);
        }
        private void btn33Click(Object sender, EventArgs e)
        {
            hidebtn(33);
        }
        private void btn34Click(Object sender, EventArgs e)
        {
            hidebtn(34);
        }
        private void btn35Click(Object sender, EventArgs e)
        {
            hidebtn(35);
        }
        private void btn36Click(Object sender, EventArgs e)
        {
            hidebtn(36);
        }
        private void btn37Click(Object sender, EventArgs e)
        {
            hidebtn(37);
        }
        private void btn38Click(Object sender, EventArgs e)
        {
            hidebtn(38);
        }
        private void btn39Click(Object sender, EventArgs e)
        {
            hidebtn(39);
        }
        private void btn40Click(Object sender, EventArgs e)
        {
            hidebtn(40);
        }
        private void btn41Click(Object sender, EventArgs e)
        {
            hidebtn(41);
        }
        private void btn42Click(Object sender, EventArgs e)
        {
            hidebtn(42);
        }
        private void btn43Click(Object sender, EventArgs e)
        {
            hidebtn(43);
        }
        private void btn44Click(Object sender, EventArgs e)
        {
            hidebtn(44);
        }
        private void btn45Click(Object sender, EventArgs e)
        {
            hidebtn(45);
        }
        private void btn46Click(Object sender, EventArgs e)
        {
            hidebtn(46);
        }
        private void btn47Click(Object sender, EventArgs e)
        {
            hidebtn(47);
        }
        private void btn48Click(Object sender, EventArgs e)
        {
            hidebtn(48);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //A이상 남은것 배열 리셋
            A_UP.Clear();
            //남은갯수 리셋
            resetcount();
            change_count = change_count + 1;
            label5.Text = change_count.ToString() + "회";
            for(int i = 0; i < boxsize; i++)
            {
                btn[i].Visible = true;
            }
            changeFunc();

            //SSS판 만들기
            makeSSS();

            hint01.Text = "X";
            hint02.Text = "X";
            hint03.Text = "X";
            hint_count = 1;
        }

        //A이상만 넣기
        static ArrayList A_UP = new ArrayList();

        private void makeSSS()
        {
            ArrayList box = new ArrayList();
            box.Add("SSS");
            box.Add("SS");
            box.Add("SS");
            for (int i = 0; i < 6; i++)
            {
                box.Add("S");
            }
            for (int i = 0; i < 10; i++)
            {
                box.Add("A");
            }
            for (int i = 0; i < 18; i++)
            {
                box.Add("B");
            }
            for (int i = 0; i < 12; i++)
            {
                box.Add("C");
            }

            Random rd = new Random();
            for (int i = 0; i < 200; i++)
            {
                String tmp = "";
                int idx1 = rd.Next(0, 49);
                int idx2 = rd.Next(0, 49);

                tmp = box[idx1].ToString();
                box[idx1] = box[idx2];
                box[idx2] = tmp;
            }

            //C 배치 정렬
            int count = 0;
            while (true)
            {
                count = 0;
                for (int i = 0; i < 48; i++)
                {
                    string tmp = box[i].ToString();
                    if (tmp == "C")
                    {
                        if (box[i + 1].ToString() == "C")
                        {
                            while (true)
                            {
                                int idx1 = rd.Next(0, 49);
                                if (box[idx1].ToString() != "C")
                                {
                                    string ttmp = box[idx1].ToString();
                                    box[idx1] = box[i + 1];
                                    box[i + 1] = ttmp;
                                    break;
                                }
                            }
                        }
                        else
                        {
                            count++;
                        }
                    }
                }
                if (count >= 11)
                {
                    break;
                }
            }
            for (int i = 0; i < boxsize; i++)
            {
                if(box[i].ToString() == "C")
                {
                    labels[i].BackColor = Color.FromArgb(130, 130, 130);
                }
                else if(box[i].ToString() == "B")
                {
                    labels[i].BackColor = Color.FromArgb(255, 136, 55);
                }
                else if (box[i].ToString() == "A")
                {
                    labels[i].BackColor = Color.FromArgb(0, 204, 97);
                    A_UP.Add(i);
                }
                else if (box[i].ToString() == "S")
                {
                    labels[i].BackColor = Color.FromArgb(66, 164, 249);
                    A_UP.Add(i);
                }
                else if (box[i].ToString() == "SS")
                {
                    labels[i].BackColor = Color.FromArgb(123, 64, 242);
                    A_UP.Add(i);
                }
                else
                {
                    labels[i].BackColor = Color.FromArgb(255, 60, 132);
                    A_UP.Add(i);
                }
                labels[i].Text = box[i].ToString();
                labels[i].ForeColor = Color.FromArgb(255, 255, 255);
            }
        }
    }
}
