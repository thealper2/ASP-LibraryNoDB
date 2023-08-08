using System.ComponentModel.DataAnnotations;

namespace LibraryNoDB.Models
{
    public class Product
    {
        public int Id { get; set; }

        [StringLength(50, ErrorMessage = "Kitap isim alanı en fazla 50 karakter olabilir.")]
        [Required(ErrorMessage="Kitap ismi alanı boş olamaz.")]
        public string BookName { get; set; }

        [StringLength(50, ErrorMessage = "Kitap yazar alanı en fazla 50 karakter olabilir.")]
        [Required(ErrorMessage = "Kitap yazar alanı boş olamaz.")]
        public string BookAuthor { get; set; }

        [Range(1, 10, ErrorMessage="Baskı sayısı 1-10 arası olmalıdır.")]
        [Required(ErrorMessage = "Baskı sayısı alanı boş olamaz.")]
        public int BookEdition { get; set; }

        [Range(1, 500, ErrorMessage = "Kitap fiyatı 1-500 arası olmalıdır.")]
        [Required(ErrorMessage = "Kitap fiyatı alanı boş olamaz.")]
        public int BookPrice { get; set; }

        [Range(1, 100, ErrorMessage = "Kitap stok sayısı 1-100 arası olmalıdır.")]
        [Required(ErrorMessage = "Kitap stok sayısı alanı boş olamaz.")]
        public int BookStock { get; set; }

        [Required(ErrorMessage = "Kitap yayınlanma tarihi alanı boş olamaz.")]
        public DateTime BookPublishDate { get; set; }
    }
}
