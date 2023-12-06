using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P1206
{
    public class RentalViewer
    {
        [Browsable(false)]
        public int RentalId { get; set; }

        [DisplayName("자동차 모델")]
        public string CarModel { get; set; }

        [DisplayName("자동차 색상")]
        public string CarColor { get; set; }

        [DisplayName("제조사")]
        public string MakerName { get; set; }

        [DisplayName("빌린 사람")]
        public string CustomerName { get; set; }

        [DisplayName("대여 날짜")]
        public DateTime RentalDate { get; set; }

        [DisplayName("반납 날짜")]
        public DateTime? ReturnDate { get; set; }

    }
}
