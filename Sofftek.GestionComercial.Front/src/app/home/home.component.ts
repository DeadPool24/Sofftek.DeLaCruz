import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ArticuloModel } from './Model/ArticuloModel';
import { ArticuloService } from './services/tarea.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  articulo: ArticuloModel = new ArticuloModel();
  listaArticulos : ArticuloModel[] = [];
  constructor(private service : ArticuloService) { }

  ngOnInit(): void {
    this.listarArticulos();
  }

  guardarArticulo(f: NgForm) {
    if (f.invalid) {
      alert("Formulario incompleto o invalido");
    } else {
      this.service.postArticulo(this.articulo).subscribe((resp: any) => {
        console.log(resp);
        if (resp.success) {
          alert("proceso exitoso");
          this.listarArticulos();
        } else {
          alert("existe un error");
        }
      });
    }
  }

  listarArticulos(){
    this.service.getArticulos()
    .subscribe((resp:any)=>{
      console.log(resp);
    this.listaArticulos = resp.data;
    })
  }

}
