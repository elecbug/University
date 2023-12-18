using ExamF.bikeDB;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace ExamF
{
    public partial class MainForm : Form
    {
        private Button[] Buttons = new Button[4];
        private Label[] Labels = new Label[4];

        public MainForm()
        {
            InitializeComponent();

            Buttons[0] = button1;
            Buttons[1] = button2;
            Buttons[2] = button3;
            Buttons[3] = button4;

            Labels[0] = label1;
            Labels[1] = label2;
            Labels[2] = label3;
            Labels[3] = label4;

            RefreshList();
            RefreshBikeRentals();
        }

        private void RefreshBikeRentals()
        {
            using (BikeDbContext db = new BikeDbContext())
            {
                for (int i = 0; i < Buttons.Length; i++)
                {
                    bool used = db.Bikes.Where(x => x.Id - 1 == i).First().Used;

                    ButtonSet(i, used);
                    if (used)
                        Labels[i].Text = "대여중";
                    else
                        Labels[i].Text = "대여불가";
                }
            }
        }

        private void ButtonSet(int buttonID, bool isRentaled)
        {
            using (BikeDbContext db = new BikeDbContext())
            {
                Buttons[buttonID].Text = (buttonID + 1) + "호기\r\n" +
                    db.Bikes.First(x => x.Id == buttonID + 1).Battery + "%";

                if (isRentaled == true)
                {
                    Buttons[buttonID].BackColor = Color.LightGreen;
                    db.Bikes.First(x => x.Id == buttonID + 1).Used = false;

                    bool bases = true; 
                    Buttons[buttonID].Click += (s, e) =>
                    {
                        if (bases == true)
                        {
                            using (BikeDbContext db = new BikeDbContext())
                            {
                                db.RentalHistories.Add(new RentalHistory()
                                {
                                    BikeId = buttonID + 1,
                                    MemberId = 1,
                                    RentalTime = DateTime.Now,
                                    ReturnTime = null,
                                });

                                Buttons[buttonID].BackColor = Color.OrangeRed;
                                db.SaveChanges();
                                RefreshList();
                            }
                        }
                        else
                        {
                            using (BikeDbContext db = new BikeDbContext())
                            {
                                db.RentalHistories.Where(x => x.BikeId == buttonID + 1
                                    && x.ReturnTime == null).First().ReturnTime = DateTime.Now;

                                Buttons[buttonID].BackColor = Color.LightGreen;
                                db.SaveChanges();
                                RefreshList();
                            }
                        }
                    };
                }
                else if (isRentaled == false)
                {
                    Buttons[buttonID].BackColor = Color.OrangeRed;
                    bool bases = false;
                    db.Bikes.First(x => x.Id == buttonID + 1).Used = true;

                    Buttons[buttonID].Click += (s, e) =>
                    {
                        if (bases == true)
                        {
                            using (BikeDbContext db = new BikeDbContext())
                            {
                                db.RentalHistories.Add(new RentalHistory()
                                {
                                    BikeId = buttonID + 1,
                                    MemberId = 1,
                                    RentalTime = DateTime.Now,
                                    ReturnTime = null,
                                });

                                Buttons[buttonID].BackColor = Color.OrangeRed;
                                db.SaveChanges();
                                RefreshList();
                            }
                        }
                        else
                        {
                            using (BikeDbContext db = new BikeDbContext())
                            {
                                db.RentalHistories.Where(x => x.BikeId == buttonID + 1
                                    && x.ReturnTime == null).First().ReturnTime = DateTime.Now;

                                Buttons[buttonID].BackColor = Color.LightGreen;
                                db.SaveChanges();
                                RefreshList();
                            }
                        }
                    };
                }
            }
        }

        private void RefreshList()
        {
            using (BikeDbContext db = new BikeDbContext())
            {
                {
                    List<RentalView> list = new List<RentalView>();
                    foreach (var item in db.RentalHistories
                                            .Include(p => p.Member))
                    {
                        RentalView view = new RentalView()
                        {
                            Id = item.Id,
                            BikeName = item.BikeId + "호기",
                            MemberName = item.Member.Name,
                            RentalTime = item.RentalTime,
                            ReturnTime = item.ReturnTime,
                        };

                        list.Add(view);
                    }

                    this.dataGridView1.DataSource = list;
                }
                {
                    List<RechargeView> list = new List<RechargeView>();
                    foreach (var item in db.RechargeHistories)
                    {
                        RechargeView view = new RechargeView()
                        {
                            Id = item.Id,
                            BikeName = item.BikeId + "호기",
                            RechargeTime = item.RechargeTime,
                        };

                        list.Add(view);
                    }

                    this.dataGridView2.DataSource = list;
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            using (BikeDbContext db = new BikeDbContext())
            {
                db.RechargeHistories.Add(new RechargeHistory()
                {
                    BikeId = 4,
                    RechargeTime = DateTime.Now,
                });
                db.Bikes.First(x => x.Id == 4).Battery = 100;

                db.SaveChanges();
                RefreshList();
                RefreshBikeRentals();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            using (BikeDbContext db = new BikeDbContext())
            {
                db.RechargeHistories.Add(new RechargeHistory()
                {
                    BikeId = 2,
                    RechargeTime = DateTime.Now,
                });
                db.Bikes.First(x => x.Id == 2).Battery = 100;

                db.SaveChanges();
                RefreshList();
                RefreshBikeRentals();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            using (BikeDbContext db = new BikeDbContext())
            {
                db.RechargeHistories.Add(new RechargeHistory()
                {
                    BikeId = 3,
                    RechargeTime = DateTime.Now,
                });
                db.Bikes.First(x => x.Id == 3).Battery = 100;

                db.SaveChanges();
                RefreshList();
                RefreshBikeRentals();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            using (BikeDbContext db = new BikeDbContext())
            {
                db.RechargeHistories.Add(new RechargeHistory()
                {
                    BikeId = 1,
                    RechargeTime = DateTime.Now,
                });
                db.Bikes.First(x => x.Id == 1).Battery = 100;

                db.SaveChanges();
                RefreshList();
                RefreshBikeRentals();
            }
        }
    }

    internal class RentalView
    {
        [DisplayName("순번")]
        public int Id { get; set; }
        [DisplayName("자전거이름")]
        public string BikeName { get; set; } = "";
        [DisplayName("대여자")]
        public string MemberName { get; set; } = "";
        [DisplayName("대여시간")]
        public DateTime RentalTime { get; set; }
        [DisplayName("반납시간")]
        public DateTime? ReturnTime { get; set; }
    }
    internal class RechargeView
    {
        [DisplayName("순번")]
        public int Id { get; set; }
        [DisplayName("자전거이름")]
        public string BikeName { get; set; } = "";
        [DisplayName("충전시간")]
        public DateTime RechargeTime { get; set; }
    }
}