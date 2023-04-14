using System;
using UnityEngine;

public class SortLayer : MonoBehaviour
{
	private void Awake()
	{
		if (this.rendererSort != null)
		{
			this.rendererSort.sortingLayerName = this.nameSortLayer;
			this.rendererSort.sortingOrder = this.orderInLayer;
		}
		else
		{
			this.rendererSort = base.GetComponent<MeshRenderer>();
			this.rendererSort.sortingLayerName = this.nameSortLayer;
			this.rendererSort.sortingOrder = this.orderInLayer;
		}
	}

	public string nameSortLayer = "Default";

	public int orderInLayer;

	public Renderer rendererSort;
}
