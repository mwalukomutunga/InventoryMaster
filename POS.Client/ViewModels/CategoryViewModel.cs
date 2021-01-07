using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using Google.Protobuf.WellKnownTypes;
using Grpc.Net.Client;
using POS.Client.Models;
using POSBeta.Category;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace POS.Client.ViewModels
{
    public class CategoryViewModel : BaseViewModel
    {
        readonly Category.CategoryClient client;
        public CategoryViewModel()
        {
            using var channel = GrpcChannel.ForAddress(Address);
            client = new Category.CategoryClient(channel);
            SelectedObject = new ItemCategory() { CategoryId = new Guid() };
            GridCollection = new ObservableCollection<object>();
        }

        ItemCategory _SelectedObject;
        public ItemCategory SelectedObject
        {
            get { return _SelectedObject; }
            set
            {
                SetValue(ref _SelectedObject, value);
            }
        }

        public async Task<bool> CanSaveAsync()
        {
            if (SelectedObject == null)
            {
                return IsNewRecord = false;
            }
            var item = await client.GetCategoryAsync(new CategoryModel { Id = SelectedObject.CategoryId.ToString()});
            return IsNewRecord = item == null;
        }

        [Command]
        public async Task Save()
        {
            try
            {
                await client.AddCategoryAsync(new CategoryModel { Name = SelectedObject.Name, Description = SelectedObject.Description });
                GridCollection.Insert(0, SelectedObject);
                MessageBoxService.Show("Category record saved");
            }
            catch (Exception ex)
            {
                MessageBoxService.Show(ex.InnerException.Message);
            }
            finally
            {
                SelectedObject = new ItemCategory() { };
            }

        }


        [Command]
        public async Task Delete()
        {
            try
            {
                await client.DeleteCategoryAsync(new CategoryModel { Id = SelectedObject.CategoryId.ToString(), Name = SelectedObject.Name, Description = SelectedObject.Description });
                GridCollection.Remove(SelectedObject);
                MessageBoxService.Show("Category record Deleted");
            }
            catch (Exception ex)
            {

                MessageBoxService.Show(ex.InnerException.Message);
            }
            finally
            {
                SelectedObject = new ItemCategory() { };
            }

        }

        [Command]
        public void New()
        {
            SelectedObject = new ItemCategory() { CategoryId = new Guid() };
        }
        public bool CanUpdate()
        {
            return !IsNewRecord;
        }
        [Command]
        public async Task Update()
        {
            try
            {
                await client.UpdateCategoryAsync(new CategoryModel { Id= SelectedObject.CategoryId.ToString(), Name = SelectedObject.Name, Description = SelectedObject.Description});
            }
            catch (Exception ex)
            {

                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            finally
            {
                SelectedObject = new ItemCategory() { };
                GridCollection = new ObservableCollection<object>();
            }
        }
        protected override void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                handle.Dispose();
                // Free any other managed objects here.
                //  unitOfWork.Dispose();
            }

            disposed = true;
        }


    }
}
