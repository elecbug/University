using P1108.bookDB;

namespace P1108
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.MemberLBox.DisplayMember = "Name";
            this.BookLBox.DisplayMember = "Title";
            this.SelectLBox.Format += (s, e) =>
            {
                using (BookDbContext db = new BookDbContext())
                {
                    var item = (e.ListItem as BookMember)!;
                    e.Value = db.Books.Where(x => x.Id == item.BookId)
                        .First().Title + ": " + ((item.EndDate - item.StartDate).Days + 1) + "일";
                }
            };


            RefreshList(true);
        }

        private void RefreshList(bool defaultSet = false, bool selectSet = true)
        {
            using (BookDbContext db = new BookDbContext())
            {
                this.StartDate.Value = DateTime.Now;
                this.EndDate.Value = DateTime.Now;

                if (defaultSet)
                {
                    this.MemberLBox.Items.Clear();
                    this.BookLBox.Items.Clear();

                    foreach (var item in db.Members)
                    {
                        this.MemberLBox.Items.Add(item);
                    }

                    foreach (var item in db.Books)
                    {
                        this.BookLBox.Items.Add(item);
                    }
                }

                Member member = (this.MemberLBox.SelectedItem as Member)!;
                
                if (selectSet)
                {
                    this.SelectLBox.Items.Clear();

                    if (member != null)
                    {
                        foreach (var item in db.BookMembers
                            .Where(x => x.MemberId == member.Id).ToList())
                        {
                            this.SelectLBox.Items.Add(item);
                        }
                    }
                }


                if (member != null)
                {
                    int total = 0;
                    var list = db.BookMembers.Where(x => x.MemberId == member.Id).ToList();

                    foreach (var item in list)
                    {
                        total += (item.EndDate - item.StartDate).Days + 1;
                    }

                    this.TotalLbl.Text = "대여료 총합: " + (total * 200).ToString() + "원";
                }
                else
                {
                    this.TotalLbl.Text = "대여료 총합: (회원을 선택하여 주세요)";
                }
            }
        }

        private void SelectBtn_Click(object sender, EventArgs e)
        {
            if (this.EndDate.Value < this.StartDate.Value)
            {
                MessageBox.Show("빌린 날짜가 반납 날짜보다 늦을 수 없습니다.");

                return;
            }
            using (BookDbContext db = new BookDbContext())
            {
                Member member = (this.MemberLBox.SelectedItem as Member)!;
                Book book = (this.BookLBox.SelectedItem as Book)!;

                if (member != null && book != null)
                {
                    db.BookMembers.Add(new BookMember()
                    {
                        BookId = book.Id,
                        MemberId = member.Id,
                        StartDate = this.StartDate.Value,
                        EndDate = this.EndDate.Value,
                    });

                    db.SaveChanges();

                    RefreshList(false, true);
                }
            }
        }

        private void LBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sender == this.MemberLBox)
            {
                RefreshList(false, true);
            }
            else
            {
                RefreshList(false, false);
            }
        }

        private void DeselectBtn_Click(object sender, EventArgs e)
        {

            using (BookDbContext db = new BookDbContext())
            {
                BookMember select = (this.SelectLBox.SelectedItem as BookMember)!;

                if (select != null)
                {
                    var item = db.BookMembers.Where(x => x.Id == select.Id).First();

                    db.BookMembers.Remove(item);
                    db.SaveChanges();

                    RefreshList(false, true);
                }
            }
        }
    }
}