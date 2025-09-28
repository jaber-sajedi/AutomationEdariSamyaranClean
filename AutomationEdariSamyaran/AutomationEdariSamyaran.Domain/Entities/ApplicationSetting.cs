using AutomationEdariSamyaran.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutomationEdariSamyaran.Domain.Entities
{
    public class ApplicationSetting
    {
        [Key]
        public int Id { get; set; }

        public string Key { get; set; } = string.Empty;

        public string Value { get; set; } = string.Empty;

         
        [NotMapped]
        public ApplicationSettingKey KeyEnum
        {
            get => Enum.TryParse<ApplicationSettingKey>(Key, out var result) ? result : default;
            set => Key = value.ToString();
        }
    }


}
