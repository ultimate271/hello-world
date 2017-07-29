namespace DatabaseFirstEntityPlayground
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("WLMovement")]
    public partial class WLMovement
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public WLMovement()
        {
            WLWorkoutTimed_Movement = new HashSet<WLWorkoutTimed_Movement>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int movement_id { get; set; }

        public int movementType_id { get; set; }

        [Required]
        [StringLength(20)]
        public string name { get; set; }

        public virtual WLMovementType WLMovementType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WLWorkoutTimed_Movement> WLWorkoutTimed_Movement { get; set; }
    }
}
