using System;

public enum JobType
{
    HireStaff,
    StaffWork,
    StaffPay,
    WaitingAudition,
}

public class Job
{
    public int CurrentTime;
    public int RequiredTime;
    public float Progress => (float)CurrentTime / RequiredTime;
    public JobType Type;
    public bool Recurring = false;

    public Action<Job> OnProcess;
    public Action OnEnd;
    public bool Finished;

    public virtual void Process() {
        CurrentTime++;
        OnProcess?.Invoke(this);
        if (CurrentTime >= RequiredTime) {
            OnEnd?.Invoke();
            if (Recurring) {
                CurrentTime = 0;
            } else {
                Finished = true;
            }
        }
    }
}

public class HireStaffJob : Job
{
    public HireStaffJob() {
        Type = JobType.HireStaff;
    }
}



public class StaffWorkJob : Job
{
    public Staff Staff;

    public StaffWorkJob(Staff staff) {
        Type = JobType.StaffWork;
        Recurring = true;
        Staff = staff;
        RequiredTime = ModelStaffGrade.Get(staff.GradeId).UpdateTime;
    }
}

public class StaffPayJob : Job
{
    public Staff Staff;

    public StaffPayJob(Staff staff) {
        Type = JobType.StaffPay;
        Recurring = true;
        Staff = staff;
        RequiredTime = 7 * 30;
    }
}

public class FacilityPayJob : Job
{
    public int FacilityID;

    public FacilityPayJob(int facilityID) {
        FacilityID = facilityID;
        Recurring = true;
        RequiredTime = 7 * 30;
    }
}

public class WaitingAuditionJob : Job
{
    public WaitingAuditionJob() {
        Type = JobType.WaitingAudition;
    }
}