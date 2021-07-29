using AssetRipper.Project;
using AssetRipper.Parser.Asset;
using AssetRipper.Classes.Misc;
using AssetRipper.IO.Asset;
using AssetRipper.YAML;
using System.Collections.Generic;

namespace AssetRipper.Classes.LODGroup
{
	public class LODRenderer : IAssetReadable, IYAMLExportable, IDependent
	{
		public LODRenderer() { }
		public void Read(AssetReader reader)
		{
			Renderer.Read(reader);
		}

		public IEnumerable<PPtr<Object.Object>> FetchDependencies(DependencyContext context)
		{
			yield return context.FetchDependency(Renderer, RendererName);
		}

		public YAMLNode ExportYAML(IExportContainer container)
		{
			YAMLMappingNode node = new YAMLMappingNode();
			node.Add(RendererName, Renderer.ExportYAML(container));
			return node;
		}

		public const string RendererName = "renderer";

		public PPtr<Renderer.Renderer> Renderer = new();
	}
}
