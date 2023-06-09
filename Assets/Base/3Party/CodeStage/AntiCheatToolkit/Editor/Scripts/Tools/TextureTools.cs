﻿#region copyright
// ------------------------------------------------------
// Copyright (C) Dmitriy Yukhanov [https://codestage.net]
// ------------------------------------------------------
#endregion

namespace CodeStage.AntiCheat.EditorCode
{
	using System.Collections.Generic;
	using System.IO;
	using Common;
	using UnityEditor;
	using UnityEngine;

	internal static class TextureTools
	{
		private static readonly Dictionary<string, Texture2D> CachedTextures = new Dictionary<string, Texture2D>();

		public static Texture2D GetTexture(string fileName)
		{
			return GetTexture(fileName, false, false);
		}

		public static Texture2D GetIconTexture(string fileName, bool fromEditor = false)
		{
			return GetTexture(fileName, true, fromEditor);
		}

		private static Texture2D GetTexture(string fileName, bool icon, bool fromEditor)
		{
			Texture2D result;
			var isDark = EditorGUIUtility.isProSkin;

			var path = fileName;

			if (!fromEditor)
			{
				path = Path.Combine(EditorTools.GetACTkDirectory(), "Editor/Textures/For" + (isDark ? "Dark/" : "Bright/") + (icon ? "Icons/" : "") + fileName);
			}

			if (CachedTextures.ContainsKey(path))
			{
				result = CachedTextures[path];
			}
			else
			{
				if (!fromEditor)
				{
					result = AssetDatabase.LoadAssetAtPath(path, typeof(Texture2D)) as Texture2D;
				}
				else
				{
					result = EditorGUIUtility.FindTexture(path);
				}

				if (result == null)
				{
					Debug.LogError(ACTk.ConstructErrorForSupport("Some error occurred while looking for image\n" + path));
				}
				else
				{
					CachedTextures[path] = result;
				}
			}
			return result;
		}
	}

	internal static class Icons
	{
		public static Texture API => TextureTools.GetIconTexture("API.png");
		public static Texture Forum => TextureTools.GetIconTexture("Forum.png");
		public static Texture Discord => TextureTools.GetIconTexture("Discord.png");
		public static Texture Manual => TextureTools.GetIconTexture("Manual.png");
		public static Texture Help => TextureTools.GetIconTexture("Help.png");
		public static Texture Home => TextureTools.GetIconTexture("Home.png");
		public static Texture Support => TextureTools.GetIconTexture("Support.png");
		public static Texture Star => TextureTools.GetIconTexture("Star.png");
	}

	internal static class Images
	{
		public static Texture Logo => TextureTools.GetTexture("Logo.png");
	}
}