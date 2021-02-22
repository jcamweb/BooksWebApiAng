import { Component, OnInit } from '@angular/core';
import { BookService } from 'src/app/shared/book.service';
import { Book } from 'src/app/shared/book.model';
import { ToastrService } from 'ngx-toastr';
@Component({
  selector: 'app-books',
  templateUrl: './books.component.html',
  styles: []
})
export class BooksComponent implements OnInit {

  constructor(public service: BookService,
    private toastr: ToastrService) { }

  ngOnInit(): void {

    this.service.refreshList();
  }

  populateForm(selectedRecord: Book) {
    this.service.formData = Object.assign({}, selectedRecord);
  }

  onDelete(id: number) {
    if (confirm('Confirma eliminar este registro')) {
      this.service.deleteBook(id)
        .subscribe(
          res => {
            this.service.refreshList();
            this.toastr.error("Eliminado correctamente", 'Books');
          },
          err => { console.log(err) }
        )
    }
  }

}
