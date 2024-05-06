using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab10
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        const double rusLam = -2;
        const double croLam = -1.8;
        const double frcLam = -2.3;
        const double gerLam = -2.4;
        const double mexLam = -2;
        const double porLam = -2.2;
        const double argLam = -2.4;
        const double braLam = -2.6;

        double winLam1, winLam2, winLam3, winLam4, halfLam1, halfLam2, winner;

        public int GetPoints(double lambda)
        {
            Random r = new Random();
            double p = r.NextDouble();
            int points = 0;
            double S = Math.Log(p);
            while (S > lambda)
            {
                points++;
                p = r.NextDouble();
                S += Math.Log(p);
            }
            return points;
        }

        public double PlayMatch(double lam1, Label t1, PictureBox p1, double lam2, Label t2, PictureBox p2, PictureBox winner)
        {
            double PointsT1 = 0;
            double PointsT2 = 0;
            double winnerLam;
            while (PointsT1 == PointsT2)
            {
                PointsT1 = GetPoints(lam1);
                PointsT2 = GetPoints(lam2);
            }
            t1.Text = PointsT1.ToString();
            t2.Text = PointsT2.ToString();

            if (PointsT1 > PointsT2)
            {
                winnerLam = lam1;
                winner.Image = p1.Image;
            }
            else
            {
                winnerLam = lam2;
                winner.Image = p2.Image;
            }

            return winnerLam;
        }

        private void Startbt_1_Click(object sender, EventArgs e)
        {
            Startbt.Click -= new EventHandler(Startbt_1_Click);
            Startbt.Click += new EventHandler(Startbt_2_Click);
            Clear();

            winLam1 = PlayMatch(rusLam, points1, team1, croLam, points2, team2, picWin1);
            winLam2 = PlayMatch(frcLam, points3, team3, gerLam, points4, team4, picWin2);
            winLam3 = PlayMatch(mexLam, points5, team5, porLam, points6, team6, picWin3);
            winLam4 = PlayMatch(argLam, points7, team7, braLam, points8, team8, picWin4);
        }
        private void Startbt_2_Click(object sender, EventArgs e)
        {
            Startbt.Click -= new EventHandler(Startbt_2_Click);
            Startbt.Click += new EventHandler(Startbt_3_Click);
            halfLam1 = PlayMatch(winLam1, pointsW1, picWin1, winLam2, pointsW2, picWin2, picHalf1);
            halfLam2 = PlayMatch(winLam3, pointsW3, picWin3, winLam4, pointsW4, picWin4, picHalf2);
            pointsW1.Visible = true;
            pointsW2.Visible = true;
            pointsW3.Visible = true;
            pointsW4.Visible = true;
        }
        private void Startbt_3_Click(object sender, EventArgs e)
        {
            Startbt.Click -= new EventHandler(Startbt_3_Click);
            Startbt.Click += new EventHandler(Startbt_1_Click);
            winner = PlayMatch(halfLam1, pointsH1, picHalf1, halfLam2, pointsH2, picHalf2, picWinner);
            label1.Visible = true;
            pointsH1.Visible = true;
            pointsH2.Visible = true;
        }

        public void Clear()
        {
            picHalf1.Image= null;
            picHalf2.Image= null;
            picWinner.Image= null;
            pointsW1.Visible = false;
            pointsW2.Visible = false;
            pointsW3.Visible = false;
            pointsW4.Visible = false;
            pointsH1.Visible= false;
            pointsH2.Visible= false;
            label1.Visible = false;
        }
    }
}
