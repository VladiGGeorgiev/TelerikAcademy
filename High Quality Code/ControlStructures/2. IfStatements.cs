Potato potato = new Potato();
//... 
if (potato != null)
{	
	if(potato.HasBeenPeeled && !potato.IsRotten)
	{
		Cook(potato);
	}
}

//Second statement

bool xCoordAreInField = (x >= MIN_X) && (x <= MAX_X);
bool yCoordAreInField = (y >= MIN_Y) && (y <= MAX_Y);
if (xCoordAreInField && yCoordAreInField && !isVisitCell)
{
   VisitCell();
}
