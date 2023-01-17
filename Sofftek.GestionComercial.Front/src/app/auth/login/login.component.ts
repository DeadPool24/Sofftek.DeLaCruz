import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthServiceService } from '../Service/auth-service.service';
import { LocalStorageServiceService } from '../Service/local-storage-service.service';
import jwtDecode from 'jwt-decode';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  frmLogin = new FormGroup({
    user: new FormControl(),
    password: new FormControl()
  });

  isLoading: boolean = true;
  buttonClicked = false;

  isLogin: boolean = false;
  isShow: boolean = true;
  stateText: string = "";

  tokenDecode: any;

  //eye-off-outline
  isShowText: string = "eye-outline";
  typeInput = "password";

  constructor(
    private router: Router,
    private authService: AuthServiceService,
    private localStorageService: LocalStorageServiceService
  ) { }

  ngOnInit(): void {
    localStorage.clear();

    setTimeout(() => {
      this.isLoading = false;
    }, 1000);
  }
  get f(){
    return this.frmLogin.controls;
  }

  validarUsuario() {
    const formData = new FormData();

    const { user, password } = this.frmLogin.value;

    if(user.trim() != '' && password.trim() != ''){
      this.buttonClicked = true;

      const dataSend = {
        user: user.trim(),
        password: password.trim()
      }
      
      this.authService.postLogin(dataSend)
      .subscribe(
        (auth : any) => {
          this.stateText = "";

          console.log(auth);
          const token = auth.accessToken;
          
          if(auth){
            this.isLogin = false;
            this.localStorageService.set("_TK",token);

            // decodificando token que debe tener el rol de usuario
            this.tokenDecode = jwtDecode(localStorage.getItem("_TK")!);

            this.router.navigateByUrl('home');
          }
        },
        ( state : any) => {
          this.buttonClicked = false;
          this.isLogin = true;

          const { Message } = state.error;
          this.stateText = `El usuario ${user} y/o contraseña son incorrectos`;

         
          setTimeout(() => {
            this.isLogin = false;
          }, 2500);
        }
      )
    }
   
  }


}
