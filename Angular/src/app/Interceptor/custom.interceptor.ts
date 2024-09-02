import { HttpInterceptorFn } from '@angular/common/http';

export const customInterceptor: HttpInterceptorFn = (req, next) => {
  //debugger;
  const token = localStorage.getItem('agularToken');
  const colnedReq = req.clone({
    setHeaders:{
      Authorization: `Bearer ${token}`
    }
  });
  return next(colnedReq);
};
