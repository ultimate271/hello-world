namespace DatabaseFirstEntityPlayground
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("WLWorkoutType")]
    public partial class WLWorkoutType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public WLWorkoutType()
        {
            WLWorkouts = new HashSet<WLWorkout>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int workoutType_id { get; set; }

        [Required]
        [StringLength(128)]
        public string tableName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WLWorkout> WLWorkouts { get; set; }
    }
}
