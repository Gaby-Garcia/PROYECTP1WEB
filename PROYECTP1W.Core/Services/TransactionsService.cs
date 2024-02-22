using MyCompany.intranet.Core.Entities;
using MyCompany.intranet.Core.Enums;
using MyCompany.intranet.Core.Services.Interfaces;

namespace MyCompany.intranet.Core.Services;

public class BmiService : IBmiService{
    public Bmi ProcessBmi(Person person){

        var bmi = new Bmi();
        bmi.Index = person.Weight / (person.Height * person.Height);

        if(bmi.Index < 18.5){
            bmi.BmiType = BmiType.Low;
        
        }
        else if(bmi.Index >= 18.5 && bmi.Index < 24.9)
            bmi.BmiType = BmiType.Normal;
        else if(bmi.Index >= 24.9 && bmi.Index < 29.9)
            bmi.BmiType = BmiType.Overweight;
        else if(bmi.Index >= 29.9)
            bmi.BmiType = BmiType.Obesity;
        return bmi;
    }
}