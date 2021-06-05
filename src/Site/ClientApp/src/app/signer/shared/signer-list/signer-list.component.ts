import {Component, EventEmitter, Output} from '@angular/core';
import {ISearchResult} from '../../../shared/search-result.interface';
import {BaseSearchPattern} from '../../../shared/base-search-pattern';
import {SignerService} from '../signer.service';
import {ISignerPreset} from '../signer-preset.interface';

@Component({
    selector: 'rt-signer-list',
    templateUrl: './signer-list.component.html',
    providers: [SignerService]
})
export class SignerListComponent {
    public signers: ISearchResult<ISignerPreset>;

    @Output()
    public select: EventEmitter<ISignerPreset> = new EventEmitter<ISignerPreset>();

    public constructor(private signerService: SignerService) {
        signerService.searchSigners(new BaseSearchPattern(1, 10, ''))
            .subscribe(result => {
                this.signers = result;
            });
    }

    public selected(signerPreset: ISignerPreset): void {
        this.select.emit(signerPreset);
    }
}
