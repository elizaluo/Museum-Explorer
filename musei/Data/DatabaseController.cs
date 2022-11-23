using System;
using Microsoft.Azure.Cosmos;
using System.Text.Json;

namespace musei.Data
{
    public static class DatabaseController
    {

        // query everything at launch,
        // update and create as needed
        // 

        static CosmosClient client;
        static Database db;
        static public Dictionary<string, Event> events = new Dictionary<string, Event>();
        static public Dictionary<string, Museum> museums = new Dictionary<string, Museum>();

        static DatabaseController()
        {
            client = new(
                accountEndpoint: Environment.GetEnvironmentVariable("COSMOS_ENDPOINT")!,
                authKeyOrResourceToken: Environment.GetEnvironmentVariable("COSMOS_KEY")!
            );
            db = client.GetDatabase("musei");

        }

        static Container getEventsContainer()
        {
            Container eventCont = db.GetContainer("events");
            return eventCont;
        }

        static Container getMuseumsContainer()
        {
            Container museumCont = db.GetContainer("museums");
            return museumCont;
        }

        static Container getUsersContainer()
        {
            Container userCont = db.GetContainer("users");
            return userCont;
        }


        public static async Task getAllEvents()
        {
            Container eventCont = getEventsContainer();

            var query = new QueryDefinition(query: "SELECT * FROM events");

            using FeedIterator<Event> feed = eventCont.GetItemQueryIterator<Event>(
                queryDefinition: query
            );

            while (feed.HasMoreResults)
            {
                FeedResponse<Event> response = await feed.ReadNextAsync();
                foreach (Event e in response)
                {
                    events.Add(e.id, e);
                }
            }
        }

        public static async Task getAllMuseums()
        {
            Container eventCont = getMuseumsContainer();

            var query = new QueryDefinition(query: "SELECT * FROM Museums");

            using FeedIterator<Museum> feed = eventCont.GetItemQueryIterator<Museum>(
                queryDefinition: query
            );

            while (feed.HasMoreResults)
            {
                FeedResponse<Museum> response = await feed.ReadNextAsync();
                Console.Write(response.ToString());
                foreach (Museum m in response)
                {
                    museums.Add(m.id, m);
                }
            }
        }

        public static async Task createUpdateEvent(Event e)
        {
            try
            {
                Container eventCont = getEventsContainer();

                Event createdEvent = await eventCont.UpsertItemAsync<Event>(item: e);
            }
            catch (Exception exc)
            {
                Console.Write("\n\n\n" + exc.Message + "\n\n\n");
            }
        }

        public static async Task createUpdateMuseum(Museum m)
        {
            try
            {
                Container museumCont = getMuseumsContainer();

                Museum createdMuseum = await museumCont.UpsertItemAsync<Museum>(item: m);
            }
            catch (Exception exc)
            {
                Console.Write("\n\n\n" + exc.Message + "\n\n\n");
            }
        }

        
    }
}

