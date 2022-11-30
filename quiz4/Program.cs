using System.Linq;

List<Tuple<object, int>> CountElements(object[] arr)
{
    List<Tuple<object, int>> result = new List<Tuple<object, int>>();
    List<object> found = new List<object>();
    for (int i = 0; i < arr.Length; i++)
    {
        object curr = arr[i];
        if (!found.Contains(curr))
        {
            found.Append(curr);
            int count = 1;
            for (int j=i+1; j < arr.Length; j++)
            {
                if (curr == arr[j]) count++;
            }
            result.Append(new Tuple<object, int>(curr, count));
        }
    }

    return result;
}

List<Tuple<char, int>> CountChars(string text)
{
    List<Tuple<char, int>> result = new List<Tuple<char, int>>();
    List<char> found = new List<char>();
    for (int i = 0; i < text.Length; i++)
    {
        char curr = text[i];
        if (!found.Contains(curr))
        {
            found.Append(curr);
            int count = 1;
            for (int j = i + 1; j < text.Length; j++)
            {
                if (curr == text[j]) count++;
            }
            result.Add(new Tuple<char, int>(curr, count));
        }
    }

    return result;
}

List<char> FindUppers(string text)
{
    List<char> result = new List<char>();
    foreach (char c in text)
    {
        if (c >= 'A' && c <= 'Z') result.Add(c);
    }

    return result;
}

List<double> FindBetween(double[] nums, double x, double y)
{
    List<double> result = new List<double>();

    foreach (double n in nums)
    {
        if (n > x && n < y) result.Add(n);
    }

    return result;
}

char FindCommon(string text)
{
    List<Tuple<char, int>> counts = CountChars(text);

    Tuple<char, int> max = counts[0];

    for (int i=1; i<counts.Count; i++)
    {
        if (counts[i].Item2 > max.Item2) max = counts[i];
    }

    return max.Item1;
}

class Employee
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string ID { get; set; }
    public double Salary { get; set; }

    public Department Dept
    {
        get { return Dept; }
        set
        {
            if (Dept != default(Department))
            {
                Dept.Employees.Remove(this);
            }

            if (value.Employees.Count < value.MaxEmployees)
            {
                Dept = value;
                Dept.Employees.Add(this);
            }
        }
    }

    public override string ToString()
    {
        return $"Name: {Name} {Surname}, ID: {ID}, Salary: {Salary}, Department: {Dept.Name}";
    }
}

class Department
{
    public string Name { get; set; }
    public int MaxEmployees { get; set; }

    public List<Employee> Employees { get; set; } = new List<Employee>();

    public void Employ(Employee emp)
    {
        emp.Dept = this;
    }

    public void Fire(Employee emp)
    {
        emp.Dept = default(Department);
    }

    public void PrintEmployees()
    {
        foreach (Employee emp in Employees)
        {
            Console.WriteLine(emp);
        }
    }
}