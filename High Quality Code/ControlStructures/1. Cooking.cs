public class Chef
{
	public void Cook()
    {
		Bowl bowl = GetBowl();
		
        Potato potato = GetPotato();
        Carrot carrot = GetCarrot();
        
        Peel(potato);
        Peel(carrot);
        Cut(potato);
        Cut(carrot);
		
        bowl.Add(carrot);
        bowl.Add(potato);
    }
	
    private Bowl GetBowl()
    {   
        //... 
    }
	
	private Potato GetPotato()
    {
        //...
    }
	
    private Carrot GetCarrot()
    {
        //...
    }
	
    private void Cut(Vegetable potato)
    {
        //...
    }
}
