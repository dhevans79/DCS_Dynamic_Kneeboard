using System;
using System.Collections.Generic;
using System.Text;
using PCLStorage;

namespace DCS_Dynamic_Kneeboard
{
    class PagesStore
    {
        private static PagesStore instance = new PagesStore();
        private Dictionary<string, Page> pages = new Dictionary<string, Page>();
        private bool isLoaded = false;

        private PagesStore() { }

        public static PagesStore Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PagesStore();
                }
                return instance;
            }

        }

        public async void LoadPages()
        {
            char[] lineSeparator = Environment.NewLine.ToCharArray();
            char[] valueSeparator = "¦~¦".ToCharArray();

            int pageIdx, itemIdxIdx, itemNameIdx, itemTextIdx, itemTypeIdx, itemObjDataIdx;
            pageIdx = 0;
            itemIdxIdx = 1;
            itemNameIdx = 2;
            itemTextIdx = 3;
            itemTypeIdx = 4;
            itemObjDataIdx = 5;
            // page    ¦~¦ idx ¦~¦ name      ¦~¦ text             ¦~¦ type     ¦~¦ objData
            // Takeoff ¦~¦  1  ¦~¦ chk_gear  ¦~¦ Check Gear Lever ¦~¦ Checkbox ¦~¦ NULL
            // Takeoff ¦~¦  1  ¦~¦ chk_flap  ¦~¦ Check Flap Lever ¦~¦ Checkbox ¦~¦ NULL
            // Takeoff ¦~¦  1  ¦~¦ ins_setup ¦~¦ Enter INS Coords ¦~¦ IMG      ¦~¦ ins_data.png

            Page tmpPage;

            IFolder rootFolder = FileSystem.Current.LocalStorage;
            IFolder folder = await rootFolder.CreateFolderAsync("PageStore", CreationCollisionOption.OpenIfExists);
            IFile file = await folder.GetFileAsync("Pages.obj");
            string fileData = await file.ReadAllTextAsync();

            string[] listData = fileData.Split(lineSeparator);

            foreach (string listItem in listData)
            {
                string[] listArr = listItem.Split(valueSeparator);
                string pageName = listArr[pageIdx];
                int itemIdx = Convert.ToInt32(listArr[itemIdxIdx]);

                MyListItem myListItem = new MyListItem
                {
                    Name = listArr[itemNameIdx],
                    Text = listArr[itemTextIdx],
                    Type = listArr[itemTypeIdx],
                    ObjData = listArr[itemObjDataIdx]
                };

                if (pages.ContainsKey(pageName))
                {
                    tmpPage = (Page)pages.GetValueOrDefault(pageName);

                    ((Page)tmpPage).Items.Add(itemIdx, myListItem);
                }
                else
                {
                    tmpPage = new Page()
                    {
                        PageName = pageName
                    };

                    tmpPage.Items.Add(itemIdx, myListItem);

                    pages.Add(pageName, tmpPage);
                }

            }

            isLoaded = true;
        }

        public Page GetPage(string pageIdx)
        {
            if (!isLoaded)
                LoadPages();

            return pages.GetValueOrDefault(pageIdx);

        }

        public Dictionary<string, Page> GetAllPages()
        {
            if (!isLoaded)
                LoadPages();

            return pages;
        }
    }
}