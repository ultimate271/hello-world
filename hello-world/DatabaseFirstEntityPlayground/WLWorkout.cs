namespace DatabaseFirstEntityPlayground
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("WLWorkout")]
    public partial class WLWorkout
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int workout_id { get; set; }

        public int workoutType_id { get; set; }

        [Required]
        [StringLength(20)]
        public string name { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string comments { get; set; }

        public virtual WLWorkoutType WLWorkoutType { get; set; }
    }
}
