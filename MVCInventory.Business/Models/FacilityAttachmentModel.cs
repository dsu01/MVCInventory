using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCInventory.Business.Models
{
    public class FacilityAttachmentModel
    {
        public System.Guid Id { get; set; }
        [StringLength(200)]
        [Required]
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public byte[] Data { get; set; }
        public System.DateTime? CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public bool? IsActive { get; set; }
        public string Title { get; set; }
        public string FacilityName { get; set; }
    }
}
