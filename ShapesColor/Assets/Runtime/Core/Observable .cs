using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Observable<T> : IEquatable<Observable<T>>
{
	private T internalValue;

	public Observable(T internalValue)
	{
		this.internalValue = internalValue;
	}

	public Action<Observable<T>> OnChanged;

	public Observable()
	{
		internalValue = typeof(T) == typeof(string) ? (T)(object)string.Empty : default;
	}

	public void AddListener(Action<Observable<T>> listener)
	{
		OnChanged += listener;
	}

	public void RemoveListeners()
	{
		OnChanged = null;
	}

	public T Value
	{
		get => internalValue;
		set
		{
			if (value.Equals(internalValue))
			{
				return;
			}

			var oldValue = internalValue;
			internalValue = value;
			OnChanged?.Invoke(this);
		}
	}

	public void Set(T value)
	{
		Value = value;
	
	}

	public T Get()
	{
		return Value;
	}

	public static implicit operator T(Observable<T> observable)
	{
		return observable.internalValue;
	}

	public override string ToString()
	{
		return internalValue.ToString();
	}

	public bool Equals(Observable<T> other)
	{
		return other != null && other.internalValue.Equals(internalValue);
	}

	public override bool Equals(object other)
	{
		var observable = other as Observable<T>;
		return observable != null && observable.internalValue.Equals(internalValue);
	}

	public override int GetHashCode()
	{
		return internalValue.GetHashCode();
	}
}
