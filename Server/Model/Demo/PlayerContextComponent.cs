using System.Collections.Generic;
using System.Linq;

namespace ET
{
	public class PlayerComponentSystem : AwakeSystem<PlayerContextComponent>
	{
		public override void Awake(PlayerContextComponent self)
		{
			self.Awake();
		}
	}
	
	public class PlayerContextComponent : Entity
	{
		public static PlayerContextComponent Instance { get; private set; }

		public Player MyPlayer;
		
		private readonly Dictionary<long, Player> idPlayers = new Dictionary<long, Player>();

		public void Awake()
		{
			Instance = this;
		}
		
		public void Add(Player player)
		{
			this.idPlayers.Add(player.Id, player);
		}

		public Player Get(long id)
		{
			this.idPlayers.TryGetValue(id, out Player gamer);
			return gamer;
		}

		public void Remove(long id)
		{
			this.idPlayers.Remove(id);
		}

		public int Count
		{
			get
			{
				return this.idPlayers.Count;
			}
		}

		public Player[] GetAll()
		{
			return this.idPlayers.Values.ToArray();
		}

		public override void Dispose()
		{
			if (this.IsDisposed)
			{
				return;
			}
			
			base.Dispose();

			foreach (Player player in this.idPlayers.Values)
			{
				player.Dispose();
			}

			Instance = null;
		}
	}
}