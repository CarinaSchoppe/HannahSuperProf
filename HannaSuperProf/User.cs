using System;

namespace HannaSuperProf;

public class User {
    private DateTime date;
    private string firstTime;
    private double hour;
    private int kst;
    private string kstCode;
    private string name;
    private int persID;
    private string secondTime;

    public User(int persId, string name, DateTime date, string firstTime, string secondTime, double hour, string kstCode, int kst) {
        persID = persId;
        this.name = name;
        this.date = date;
        this.firstTime = firstTime;
        this.secondTime = secondTime;
        this.hour = hour;
        this.kstCode = kstCode;
        this.kst = kst;
    }


    public int PersID {
        get => persID;
        set => persID = value;
    }

    public string Name {
        get => name;
        set => name = value ?? throw new ArgumentNullException(nameof(value));
    }

    public DateTime Date {
        get => date;
        set => date = value;
    }

    public string FirstTime {
        get => firstTime;
        set => firstTime = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string SecondTime {
        get => secondTime;
        set => secondTime = value ?? throw new ArgumentNullException(nameof(value));
    }

    public double Hour {
        get => hour;
        set => hour = value;
    }

    public string KstCode {
        get => kstCode;
        set => kstCode = value ?? throw new ArgumentNullException(nameof(value));
    }

    public int Kst {
        get => kst;
        set => kst = value;
    }

    public override string ToString() {
        return $"User: {persID} {name} {date} {firstTime} {secondTime} {hour} {kstCode} {kst}";
    }

    public bool compareUser(User other) {
        //compare all user values if they are the same or not 
        return persID == other.persID && name.Equals(other.name) && date.Equals(other.date) && firstTime.Equals(other.firstTime) && secondTime.Equals(other.secondTime) && hour.Equals(other.hour) && kstCode.Equals(other.kstCode) && kst == other.kst;
    }
}