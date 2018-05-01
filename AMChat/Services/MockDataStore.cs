using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMChat
{
    public class MockDataStore : IDataStore<Item>
    {
        List<Item> items;

        public MockDataStore()
        {
            items = new List<Item>();
            var mockItems = new List<Item>
            {
                new Item { Id = Guid.NewGuid().ToString(), ChatText = "First item",           ChatUserImage ="kitten_one.png",  IsChatViewer="true"},
                new Item { Id = Guid.NewGuid().ToString(), ChatText = "First item response",  ChatUserImage ="kitten_two",      IsChatViewer="false"},
                new Item { Id = Guid.NewGuid().ToString(), ChatText = "Second item",          ChatUserImage ="kitten_one.png",  IsChatViewer="true"},
                new Item { Id = Guid.NewGuid().ToString(), ChatText = "Second item response", ChatUserImage ="kitten_two",      IsChatViewer="false"},
                new Item { Id = Guid.NewGuid().ToString(), ChatText = "Third item",           ChatUserImage ="kitten_one.png",  IsChatViewer="true"},
                new Item { Id = Guid.NewGuid().ToString(), ChatText = "Third item response",  ChatUserImage ="kitten_two",      IsChatViewer="false"},
                new Item { Id = Guid.NewGuid().ToString(), ChatText = "Fourth item",          ChatUserImage ="kitten_one.png",  IsChatViewer="true"},
                new Item { Id = Guid.NewGuid().ToString(), ChatText = "Fourth item response", ChatUserImage ="kitten_two.png",  IsChatViewer="false"},
            };

            foreach (var item in mockItems)
            {
                items.Add(item);
            }
        }

        public async Task<bool> AddItemAsync(Item item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            var _item = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(_item);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var _item = items.Where((Item arg) => arg.Id == id).FirstOrDefault();
            items.Remove(_item);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}
