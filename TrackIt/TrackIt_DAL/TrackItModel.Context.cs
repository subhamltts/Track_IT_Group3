//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TrackIt_DAL
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class TrackItConStr : DbContext
    {
        public TrackItConStr()
            : base("name=TrackItConStr")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Activity> Activities { get; set; }
        public virtual DbSet<Activity_Tracker> Activity_Tracker { get; set; }
        public virtual DbSet<Batch> Batches { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<CourseBatch> CourseBatches { get; set; }
        public virtual DbSet<Faculty> Faculties { get; set; }
        public virtual DbSet<Participant> Participants { get; set; }
    
        public virtual ObjectResult<string> uspInsertActivity(string activity_Id, string courseBatchID, string activity_Name, Nullable<System.DateTime> activity_SDT, Nullable<System.DateTime> activity_EDT)
        {
            var activity_IdParameter = activity_Id != null ?
                new ObjectParameter("Activity_Id", activity_Id) :
                new ObjectParameter("Activity_Id", typeof(string));
    
            var courseBatchIDParameter = courseBatchID != null ?
                new ObjectParameter("CourseBatchID", courseBatchID) :
                new ObjectParameter("CourseBatchID", typeof(string));
    
            var activity_NameParameter = activity_Name != null ?
                new ObjectParameter("Activity_Name", activity_Name) :
                new ObjectParameter("Activity_Name", typeof(string));
    
            var activity_SDTParameter = activity_SDT.HasValue ?
                new ObjectParameter("Activity_SDT", activity_SDT) :
                new ObjectParameter("Activity_SDT", typeof(System.DateTime));
    
            var activity_EDTParameter = activity_EDT.HasValue ?
                new ObjectParameter("Activity_EDT", activity_EDT) :
                new ObjectParameter("Activity_EDT", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("uspInsertActivity", activity_IdParameter, courseBatchIDParameter, activity_NameParameter, activity_SDTParameter, activity_EDTParameter);
        }
    
        public virtual ObjectResult<string> uspInsertActivityTracker(string activityId, Nullable<int> p_PSNo)
        {
            var activityIdParameter = activityId != null ?
                new ObjectParameter("ActivityId", activityId) :
                new ObjectParameter("ActivityId", typeof(string));
    
            var p_PSNoParameter = p_PSNo.HasValue ?
                new ObjectParameter("P_PSNo", p_PSNo) :
                new ObjectParameter("P_PSNo", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("uspInsertActivityTracker", activityIdParameter, p_PSNoParameter);
        }
    
        public virtual ObjectResult<string> uspInsertBatch(Nullable<int> batchId, Nullable<int> f_PSNo, Nullable<int> p_PSNo)
        {
            var batchIdParameter = batchId.HasValue ?
                new ObjectParameter("BatchId", batchId) :
                new ObjectParameter("BatchId", typeof(int));
    
            var f_PSNoParameter = f_PSNo.HasValue ?
                new ObjectParameter("F_PSNo", f_PSNo) :
                new ObjectParameter("F_PSNo", typeof(int));
    
            var p_PSNoParameter = p_PSNo.HasValue ?
                new ObjectParameter("P_PSNo", p_PSNo) :
                new ObjectParameter("P_PSNo", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("uspInsertBatch", batchIdParameter, f_PSNoParameter, p_PSNoParameter);
        }
    
        public virtual ObjectResult<string> uspInsertCourse(string courseId, string courseName)
        {
            var courseIdParameter = courseId != null ?
                new ObjectParameter("CourseId", courseId) :
                new ObjectParameter("CourseId", typeof(string));
    
            var courseNameParameter = courseName != null ?
                new ObjectParameter("CourseName", courseName) :
                new ObjectParameter("CourseName", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("uspInsertCourse", courseIdParameter, courseNameParameter);
        }
    
        public virtual ObjectResult<string> uspInsertCourseBatch(string courseBatchId, string batchId, string courseId)
        {
            var courseBatchIdParameter = courseBatchId != null ?
                new ObjectParameter("CourseBatchId", courseBatchId) :
                new ObjectParameter("CourseBatchId", typeof(string));
    
            var batchIdParameter = batchId != null ?
                new ObjectParameter("BatchId", batchId) :
                new ObjectParameter("BatchId", typeof(string));
    
            var courseIdParameter = courseId != null ?
                new ObjectParameter("CourseId", courseId) :
                new ObjectParameter("CourseId", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("uspInsertCourseBatch", courseBatchIdParameter, batchIdParameter, courseIdParameter);
        }
    
        public virtual ObjectResult<string> uspInsertFaculty(Nullable<int> f_PSNo, string f_EmailId, string f_Name)
        {
            var f_PSNoParameter = f_PSNo.HasValue ?
                new ObjectParameter("F_PSNo", f_PSNo) :
                new ObjectParameter("F_PSNo", typeof(int));
    
            var f_EmailIdParameter = f_EmailId != null ?
                new ObjectParameter("F_EmailId", f_EmailId) :
                new ObjectParameter("F_EmailId", typeof(string));
    
            var f_NameParameter = f_Name != null ?
                new ObjectParameter("F_Name", f_Name) :
                new ObjectParameter("F_Name", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("uspInsertFaculty", f_PSNoParameter, f_EmailIdParameter, f_NameParameter);
        }
    
        public virtual ObjectResult<string> uspInsertParticipant(Nullable<int> p_PSNo, string p_EmailId, string p_Name)
        {
            var p_PSNoParameter = p_PSNo.HasValue ?
                new ObjectParameter("P_PSNo", p_PSNo) :
                new ObjectParameter("P_PSNo", typeof(int));
    
            var p_EmailIdParameter = p_EmailId != null ?
                new ObjectParameter("P_EmailId", p_EmailId) :
                new ObjectParameter("P_EmailId", typeof(string));
    
            var p_NameParameter = p_Name != null ?
                new ObjectParameter("P_Name", p_Name) :
                new ObjectParameter("P_Name", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("uspInsertParticipant", p_PSNoParameter, p_EmailIdParameter, p_NameParameter);
        }
    
        public virtual ObjectResult<string> uspUpdateActivityTracker(string activityId, Nullable<int> p_PSNo, string activity_Status, string gitUrl)
        {
            var activityIdParameter = activityId != null ?
                new ObjectParameter("ActivityId", activityId) :
                new ObjectParameter("ActivityId", typeof(string));
    
            var p_PSNoParameter = p_PSNo.HasValue ?
                new ObjectParameter("P_PSNo", p_PSNo) :
                new ObjectParameter("P_PSNo", typeof(int));
    
            var activity_StatusParameter = activity_Status != null ?
                new ObjectParameter("Activity_Status", activity_Status) :
                new ObjectParameter("Activity_Status", typeof(string));
    
            var gitUrlParameter = gitUrl != null ?
                new ObjectParameter("GitUrl", gitUrl) :
                new ObjectParameter("GitUrl", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("uspUpdateActivityTracker", activityIdParameter, p_PSNoParameter, activity_StatusParameter, gitUrlParameter);
        }
    }
}
