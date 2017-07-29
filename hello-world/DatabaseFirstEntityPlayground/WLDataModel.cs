namespace DatabaseFirstEntityPlayground {
	using System;
	using System.Data.Entity;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Linq;

	public partial class WLDataModel : DbContext {
		public WLDataModel()
			: base("name=WLDataModel") {
		}

		public virtual DbSet<WLMovement> WLMovements { get; set; }
		public virtual DbSet<WLMovementAir> WLMovementAirs { get; set; }
		public virtual DbSet<WLMovementType> WLMovementTypes { get; set; }
		public virtual DbSet<WLMovementWeighted> WLMovementWeighteds { get; set; }
		public virtual DbSet<WLWorkout> WLWorkouts { get; set; }
		public virtual DbSet<WLWorkoutDescriptive> WLWorkoutDescriptives { get; set; }
		public virtual DbSet<WLWorkoutTimed> WLWorkoutTimeds { get; set; }
		public virtual DbSet<WLWorkoutTimed_Movement> WLWorkoutTimed_Movement { get; set; }
		public virtual DbSet<WLWorkoutType> WLWorkoutTypes { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder) {
			modelBuilder.Entity<WLMovementType>()
				.HasMany(e => e.WLMovements)
				.WithRequired(e => e.WLMovementType)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<WLWorkout>()
				.Property(e => e.comments)
				.IsUnicode(false);

			modelBuilder.Entity<WLWorkoutDescriptive>()
				.Property(e => e.description)
				.IsUnicode(false);

			modelBuilder.Entity<WLWorkoutTimed>()
				.HasMany(e => e.WLWorkoutTimed_Movement)
				.WithRequired(e => e.WLWorkoutTimed)
				.HasForeignKey(e => new { e.workout_id, e.workoutType_id });

			modelBuilder.Entity<WLWorkoutType>()
				.HasMany(e => e.WLWorkouts)
				.WithRequired(e => e.WLWorkoutType)
				.WillCascadeOnDelete(false);
		}
	}
}
