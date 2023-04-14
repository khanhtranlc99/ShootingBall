using System;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
	private void Awake()
	{
		this.PoolLength = 10;
	}

	public void Initialize()
	{
		this.PooledObjects = new List<GameObject>();
		for (int i = 0; i < this.PoolLength; i++)
		{
			this.CreateObjectInPool();
		}
	}

	public void DisableAllObject()
	{
		foreach (GameObject gameObject in this.PooledObjects)
		{
			if (gameObject.activeInHierarchy)
			{
				gameObject.SetActive(false);
			}
		}
	}

	public void Initialize(params Type[] componentsToAdd)
	{
		this.componentsToAdd = componentsToAdd;
		this.Initialize();
	}

	public GameObject GetPooledObject()
	{
		for (int i = 0; i < this.PooledObjects.Count; i++)
		{
			if (!this.PooledObjects[i].activeInHierarchy)
			{
				return this.PooledObjects[i];
			}
		}
		int count = this.PooledObjects.Count;
		this.CreateObjectInPool();
		return this.PooledObjects[count];
	}

	public bool CheckPoolerObjectActive()
	{
		foreach (GameObject gameObject in this.PooledObjects)
		{
			if (gameObject.activeInHierarchy)
			{
				return true;
			}
		}
		return false;
	}

	private void CreateObjectInPool()
	{
		GameObject gameObject;
		if (this.PooledObject == null)
		{
			gameObject = new GameObject(base.name + " PooledObject");
		}
		else
		{
			gameObject = UnityEngine.Object.Instantiate<GameObject>(this.PooledObject);
		}
		gameObject.SetActive(false);
		this.PooledObjects.Add(gameObject);
		if (this.componentsToAdd != null)
		{
			foreach (Type componentType in this.componentsToAdd)
			{
				gameObject.AddComponent(componentType);
			}
		}
		if (this.Parent != null)
		{
			gameObject.transform.parent = this.Parent;
		}
		else
		{
			gameObject.transform.parent = base.transform;
		}
	}

	public Transform Parent;

	public GameObject PooledObject;

	private List<GameObject> PooledObjects;

	public int PoolLength;

	private Type[] componentsToAdd;
}
