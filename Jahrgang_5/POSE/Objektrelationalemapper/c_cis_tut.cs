
public class Tutorial
{
	public int TutorialId { get; set; }
	public string Name { get; set; }
	
	public int ExampleId { get; set; } //1-n Beziehung
	[ForeignKey("ExampleId")] //Syntax für das Entity-Framework
	public virtual Example Example { get; set; }
	//damit Fremdschlüssel richtig angelegt werden
}

public class TutorialDbContext : DbContext
{
	public DbSet<Tutorial> Tutorials { get; set; }
}


//Beispiel Create
public void Create(Tutorial obj)
{
	using (TutorialContext ctx = new TutorialContext())
	{
		ctx.Set<Tutorial>().Add(obj);
		ctx.SaveChanges();
	}
}

//Get entspricht Read -- speziell z.B. IDs über .Find
public Tutorial GetById(int id)
{
	using (TutorialContext ctx = new TutorialContext())
	{
		return ctx.Set<Tutorial>().Find(id);
	}
}

//In der Datei Configurations.cs
protected override void Seed(TutorialDataLayer.TutorialDbContext context)
{
	Tutorial tut1 = new Tutorial(){...};
	//weitere Objekte anlegen, falls gewünscht
	context.Tutorial.AddOrUpdate(tut1);
	
}

