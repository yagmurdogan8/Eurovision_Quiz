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
using System.Diagnostics;

namespace ProgrammingLanguageConceptsA4
{
    public partial class Form1 : Form
    {
        EventLog eventLog1 = new EventLog();

        ArrayList questionRow = new ArrayList();
        Grade popUp = new Grade();
        int grade;

        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Login objLog = new Login();
            Question q1 = new Question();
            Question2 q2 = new Question2();
            Question3 q3 = new Question3();

            questionRow.Add(q1);
            questionRow.Add(q2);
            questionRow.Add(q3);

            pnlHome.Controls.Add(objLog);
        }

        public void randomQuestion(ArrayList questionRow)
        {
            Random rndm = new Random();
            int random = rndm.Next(0, (questionRow.Count));

            if (questionRow.Count == 0)
            {
                this.Close();
            }
            else
            {
                pnlHome.Controls.Add((Control)questionRow[random]);
                questionRow.RemoveAt(random);
            }

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Type questionType = pnlHome.Controls[0].GetType();
            bool answer;

            if (questionType == typeof(Question))
            {
                Question q1 = (Question)pnlHome.Controls[0];
                answer = q1.check();

                if (answer) grade += 30;
            }
            else if (questionType == typeof(Question2))
            {
                Question2 q2 = (Question2)pnlHome.Controls[0];
                answer = q2.check();

                if (answer) grade += 30;
            }
            else if (questionType == typeof(Question3))
            {
                Question3 q3 = (Question3)pnlHome.Controls[0];
                answer = q3.check();

                if (answer) grade += 40;
            }
            
            pnlHome.Controls.RemoveAt(0);
            if (questionRow.Count > 1)
            {
                btnOK.Text = "OK";
                randomQuestion(questionRow);
            }
            else if (questionRow.Count == 1)
            {
                btnOK.Text = "End";
                randomQuestion(questionRow);
                
            }
            else if (questionRow.Count == 0)
            {
                popUp.gradeOfAll(grade);
                popUp.ShowDialog();
                this.Close();
            }
        }

        private void pnlHome_MouseEnter(object sender, EventArgs e)
        {
            
            lblLog.Text = "On the page!";
        }

        private void pnlHome_MouseLeave(object sender, EventArgs e)
        {
            lblLog.Text = "Off the page!";
        }

        private void pnlHome_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}