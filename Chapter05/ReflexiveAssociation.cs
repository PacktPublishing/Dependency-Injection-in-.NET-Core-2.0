public class Medicine
{
    public string Name { get; set; }
    public Medicine AlternateMedicine { get; set; }

    public Medicine(string name, Medicine altMedicine)
    {
        Name = name;
        AlternateMedicine = altMedicine;
    }   
}