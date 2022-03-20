using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPersistence<T> 
{
	T SaveData();
	void LoadData(T contract);
}
