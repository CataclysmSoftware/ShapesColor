using UnityEngine;

namespace AF
{
	public class SafeArea : MonoBehaviour
	{
		private Rect lastSafeArea = Rect.zero;

		private RectTransform rectTransform;

		public void Awake()
		{
			rectTransform = GetComponent<RectTransform>();
			Refresh();
		}

		public void Update()
		{
			Refresh();
		}

		private void Refresh()
		{
			var safeArea = Screen.safeArea;

			if (safeArea != lastSafeArea)
			{
				ApplySafeArea(safeArea);
			}
		}

		/// <summary>
		/// Set position and size for Safe Area of the Screen
		/// </summary>
		/// <param name="rect">Safea area of the screen</param>
		private void ApplySafeArea(Rect rect)
		{
			lastSafeArea = rect;
			var anchorMin = rect.position;
			var anchorMax = rect.position + rect.size;

			anchorMin.x /= Screen.width;
			anchorMin.y /= Screen.height;
			anchorMax.x /= Screen.width;
			anchorMax.y /= Screen.height;

			rectTransform.anchorMin = anchorMin;
			rectTransform.anchorMax = anchorMax;
		}
	}
}