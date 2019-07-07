import { ErrorHandler } from "@angular/core";

export class AppErrorHandler implements ErrorHandler {

  handleError(error: any): void {

    console.log("ERROR");
    /*
    this.toastyService.error({
      title: 'Error',
      msg: 'An unexpected Error happened.',
      theme: 'bootstrap',
      showClose: true,
      timeout: 5000
    });
    */
  }

}
